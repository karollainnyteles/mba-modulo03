using Microsoft.AspNetCore.Identity;

namespace TelesEducacao.WebApp.API.AccessControl;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<Guid?> RegisterAsync(string email, string senha, string roleName, CancellationToken cancellationToken)
    {
        var identityUser = new IdentityUser
        {
            Email = email,
            UserName = email,
        };

        var result = await _userManager.CreateAsync(identityUser, senha);
        if (result.Succeeded)
        {
            await AddRoleToUser(identityUser, "Aluno");
            return Guid.Parse(identityUser.Id);
        }
        return null;
    }

    public async Task<Guid?> LoginAsync(string email, string senha, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(email, senha, false, true);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                return Guid.Parse(user.Id);
            }
        }
        return null;
    }

    private async Task AddRoleToUser(IdentityUser user, string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role != null)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }
    }
}