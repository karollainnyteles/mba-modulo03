using Microsoft.AspNetCore.Mvc;
using TelesEducacao.Alunos.Application.Commands;
using TelesEducacao.Core.Communication.Mediator;

namespace TelesEducacao.WebApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IMediatorHandler _mediator;

    public AlunosController(IMediatorHandler mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{id}/Matricula/{cursoId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> AdicionarMatricula(Guid id, Guid cursoId,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new AdicionarMatriculaCommand(id, cursoId);
            await _mediator.EnviarComando(command);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}