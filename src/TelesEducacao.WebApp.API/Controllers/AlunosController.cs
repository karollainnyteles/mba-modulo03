using MediatR;
using Microsoft.AspNetCore.Mvc;
using TelesEducacao.Alunos.Application.Commands;
using TelesEducacao.Core.Communication.Mediator;
using TelesEducacao.Core.Messages.CommomMessages.Notifications;

namespace TelesEducacao.WebApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IMediatorHandler _mediatorHandler;

    public AlunosController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler) : base(mediatorHandler, notifications)
    {
        _mediatorHandler = mediatorHandler;
    }

    [HttpPost("{id}/Matricula/{cursoId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AdicionarMatricula(Guid id, Guid cursoId,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new AdicionarMatriculaCommand(id, cursoId);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            var erro = ObterMensagemErro();

            return BadRequest(new { message = erro });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}