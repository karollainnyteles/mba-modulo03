using MediatR;
using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Communication.Mediator;
using TelesEducacao.Core.Messages;
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

        _alunoRepository.AdicionarMatriculaAsync(request.AlunoId, request.CursoId);

        return await _alunoRepository.UnitOfWork.Commit();
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