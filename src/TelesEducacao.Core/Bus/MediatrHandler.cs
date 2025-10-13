using MediatR;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Core.Bus;

public class MediatrHandler : IMediatrHandler
{
    private readonly IMediator _mediator;

    public MediatrHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task PublicarEvento<T>(T evento) where T : Event
    {
        return _mediator.Publish(evento);
    }
}