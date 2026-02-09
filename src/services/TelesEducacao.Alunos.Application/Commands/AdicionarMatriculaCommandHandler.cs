using MediatR;
using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Communication.Mediator;
using TelesEducacao.Core.Messages;
using TelesEducacao.Core.Messages.CommomMessages.IntegrationEvents;
using TelesEducacao.Core.Messages.CommomMessages.Notifications;

namespace TelesEducacao.Alunos.Application.Commands;

public class AdicionarMatriculaCommandHandler : IRequestHandler<AdicionarMatriculaCommand, bool>
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly IMediatorHandler _mediatorHandler;

    public AdicionarMatriculaCommandHandler(IAlunoRepository alunoRepository, IMediatorHandler mediatorHandler)
    {
        _alunoRepository = alunoRepository;
        _mediatorHandler = mediatorHandler;
    }

    public async Task<bool> Handle(AdicionarMatriculaCommand request, CancellationToken cancellationToken)
    {
        if (!ValidarComando(request)) return false;

        var matriculaId = await _alunoRepository.AdicionarMatriculaAsync(request.AlunoId, request.CursoId);
        var result = await _alunoRepository.UnitOfWork.Commit();

        if (matriculaId.HasValue)
        {
            var matriculaAdicionadaEvent = new MatriculaAdicionadaEvent(
                matriculaId.Value,
                request.Valor,
                request.AlunoId,
                request.CursoId,
                request.NomeCartao,
                request.NumeroCartao,
                request.ExpiracaoCartao,
                request.CvvCartao
            );

            await _mediatorHandler.PublicarEvento(matriculaAdicionadaEvent);
        }

        return result;
    }

    private bool ValidarComando(Command command)
    {
        if (command.EhValido()) return true;

        foreach (var error in command.ValidationResult.Errors)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(command.MessageType, error.ErrorMessage));
        }

        return false;
    }
}