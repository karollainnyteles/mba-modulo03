using MediatR;
using Microsoft.AspNetCore.Mvc;
using TelesEducacao.Alunos.Application.Commands;
using TelesEducacao.Alunos.Application.Queries;
using TelesEducacao.Alunos.Application.Queries.Dtos;
using TelesEducacao.Conteudos.Application.Services;
using TelesEducacao.Core.Communication.Mediator;
using TelesEducacao.Core.Messages.CommomMessages.Notifications;
using TelesEducacao.WebApp.API.AccessControl;
using TelesEducacao.WebApp.API.Dtos;

namespace TelesEducacao.WebApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IAlunoQueries _alunoQueries;
    private readonly IUserService _userService;
    private readonly ICursoAppService _cursoAppService;

    public AlunosController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler, IAlunoQueries alunoQueries, IUserService userService, ICursoAppService cursoAppService) : base(mediatorHandler, notifications)
    {
        _mediatorHandler = mediatorHandler;
        _alunoQueries = alunoQueries;
        _userService = userService;
        _cursoAppService = cursoAppService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Registrar(UserDto userDto,
        CancellationToken cancellationToken)
    {
        var identityId = await _userService.RegisterAsync(userDto.Email, userDto.Senha, "Cliente", cancellationToken);

        if (identityId == null || identityId == Guid.Empty)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro ao registrar usuário." });
        }

        var command = new CriarAlunoCommand(identityId.Value);

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
    [ProducesResponseType(typeof(IEnumerable<AlunoDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> ObterTodos(
        CancellationToken cancellationToken)
    {
        var alunos = await _alunoQueries.ObterTodos();
        return Ok(alunos);
    }

    [HttpGet("{id}/Matriculas")]
    [ProducesResponseType(typeof(IEnumerable<MatriculaDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> ObterMatriculaPorAlunoId(Guid id,
        CancellationToken cancellationToken)
    {
        var alunos = await _alunoQueries.ObterMatriculasPorAlunoId(id);
        return Ok(alunos);
    }

    [HttpPost("{id}/Matricula/{cursoId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AdicionarMatricula(Guid id, Guid cursoId, AdicionarMatriculaDto matriculaDto,
        CancellationToken cancellationToken)
    {
        try
        {
            if (id != matriculaDto.AlunoId || cursoId != matriculaDto.CursoId)
            {
                return BadRequest();
            }

            var curso = await _cursoAppService.ObterPorId(cursoId);

            if (curso == null)
            {
                return BadRequest(new { message = "Curso não encontrado." });
            }

            var command = new AdicionarMatriculaCommand(
                matriculaDto.AlunoId,
                matriculaDto.CursoId,
                curso.Valor,
                matriculaDto.NomeCartao,
                matriculaDto.NumeroCartao,
                matriculaDto.ExpiracaoCartao,
                matriculaDto.CvvCartao
            );

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