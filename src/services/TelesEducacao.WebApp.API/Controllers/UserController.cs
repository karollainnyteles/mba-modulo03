using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TelesEducacao.Core.Communication.Mediator;
using TelesEducacao.Core.Messages.CommomMessages.Notifications;
using TelesEducacao.WebApp.API.AccessControl;
using TelesEducacao.WebApp.API.Dtos;
using TelesEducacao.WebApp.API.Models;

namespace TelesEducacao.WebApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly JwtSettings _jwtSettings;
    private readonly IUserService _userService;

    public UserController(IMediatorHandler mediatorHandler, INotificationHandler<DomainNotification> notifications, IUserService userService, IOptions<JwtSettings> jwtSettings) : base(mediatorHandler, notifications)
    {
        _userService = userService;
        _jwtSettings = jwtSettings.Value;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login(UserDto userDto, CancellationToken cancellationToken)
    {
        var userId = await _userService.LoginAsync(userDto.Email, userDto.Senha, cancellationToken);
        if (userId.HasValue)
            return Ok(new
            {
                token = GeneratesJwt(userId.Value),
                email = userDto.Email
            });
        return Problem("Email ou senha incorretos");
    }

    private string GeneratesJwt(Guid userId)
    {
        var id = userId.ToString();
        var claims = User.Claims.ToList();

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            Expires = DateTime.UtcNow.AddHours(_jwtSettings.Duration),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        });

        var encodedToken = tokenHandler.WriteToken(token);

        return encodedToken;
    }
}