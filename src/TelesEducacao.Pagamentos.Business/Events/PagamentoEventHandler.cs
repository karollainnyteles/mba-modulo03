using MediatR;
using TelesEducacao.Core.Messages.CommomMessages.IntegrationEvents;

namespace TelesEducacao.Pagamentos.Business.Events;

public class PagamentoEventHandler : INotificationHandler<MatriculaAdicionadaEvent>
{
    public Task Handle(MatriculaAdicionadaEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}