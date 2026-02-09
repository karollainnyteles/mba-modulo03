using MediatR;
using TelesEducacao.Alunos.Application.Commands;
using TelesEducacao.Core.Communication.Mediator;
using TelesEducacao.Core.Messages.CommomMessages.IntegrationEvents;

namespace TelesEducacao.Alunos.Application.Events;

public class MatriculaEventHandler : INotificationHandler<PagamentoRealizadoEvent>,
    INotificationHandler<PagamentoRecusadoEvent>
{
    private readonly IMediatorHandler _mediatorHandler;

    public MatriculaEventHandler(IMediatorHandler mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    public async Task Handle(PagamentoRealizadoEvent notification, CancellationToken cancellationToken)
    {
        await _mediatorHandler.EnviarComando(new AtivarMatriculaCommand(notification.MatriculaId));
    }

    public async Task Handle(PagamentoRecusadoEvent notification, CancellationToken cancellationToken)
    {
        await _mediatorHandler.EnviarComando(new CancelarMatriculaCommand(notification.MatriculaId));
    }
}