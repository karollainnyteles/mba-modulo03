using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelesEducacao.Conteudos.Application.Dtos;
using TelesEducacao.Conteudos.Application.Services;

namespace TelesEducacao.WebApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CursosController : ControllerBase
{
    private readonly ICursoAppService _cursoAppService;

    public CursosController(ICursoAppService cursoAppService)
    {
        _cursoAppService = cursoAppService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Guid>> Cria([FromForm] CriaCursoDto criaCursoDto,
        CancellationToken cancellationToken)
    {
        try
        {
            var cursoId = await _cursoAppService.Adicionar(criaCursoDto);
            return StatusCode(StatusCodes.Status201Created, cursoId);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualiza([FromBody] AtualizaCursoDto atualizaCursoDto,
        CancellationToken cancellationToken)
    {
        try
        {
            await _cursoAppService.Atualizar(atualizaCursoDto);
            return NoContent();
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Remove(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _cursoAppService.Remover(id);
            return NoContent();
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CursoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CursoDto>>> ObterTodos(CancellationToken cancellationToken)
    {
        var result = await _cursoAppService.ObterTodos();
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CursoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CursoDto>> ObterPorId(Guid id, CancellationToken cancellationToken)
    {
        var cursoDto = await _cursoAppService.ObterPorId(id);

        if (cursoDto == null)
            return NotFound();

        return Ok(cursoDto);
    }
}