using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelesEducacao.Alunos.Application.Commands;
using TelesEducacao.Alunos.Application.Queries;
using TelesEducacao.Alunos.Application.Queries.Dtos;
using TelesEducacao.Core.Communication.Mediator;
using TelesEducacao.Core.Messages.CommomMessages.Notifications;

namespace TelesEducacao.WebApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IAlunoQueries _alunoQueries;

    public AlunosController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler, IAlunoQueries alunoQueries) : base(mediatorHandler, notifications)
    {
        _mediatorHandler = mediatorHandler;
        _alunoQueries = alunoQueries;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegistrarAlunoCommand command,
        CancellationToken cancellationToken)
    {
        await _mediatorHandler.EnviarComando(command);
        if (OperacaoValida())
        {
            return StatusCode(StatusCodes.Status201Created);
        }

        var erro = ObterMensagemErro();

        return BadRequest(new { message = erro });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AlunoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AlunoDto>> ObterPorId(Guid id,
        CancellationToken cancellationToken)
    {
        var aluno = await _alunoQueries.ObterPorId(id);
        if (aluno == null)
        {
            return NotFound();
        }
        return Ok(aluno);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<AlunoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> ObterTodos(
        CancellationToken cancellationToken)
    {
        var alunos = await _alunoQueries.ObterTodos();
        return Ok(alunos);
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