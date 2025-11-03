using Microsoft.AspNetCore.Mvc;
using TelesEducacao.Conteudos.Application.Dtos;
using TelesEducacao.Conteudos.Application.Services;

namespace TelesEducacao.WebApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ConteudosController : ControllerBase
{
    private readonly ICursoAppService _cursoAppService;

    public ConteudosController(ICursoAppService cursoAppService)
    {
        _cursoAppService = cursoAppService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Guid>> Create([FromForm] CursoDto cursoDto,
        CancellationToken cancellationToken)
    {
        try
        {
            var cursoId = await _cursoAppService.Adicionar(cursoDto);
            return StatusCode(StatusCodes.Status201Created, cursoId);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}