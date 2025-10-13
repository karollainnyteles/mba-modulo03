using TelesEducacao.Core.Messages;

namespace TelesEducacao.Core.DomainObjects;

public class DomainEvent : Event
{
    public DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}