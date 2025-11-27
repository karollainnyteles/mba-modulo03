using TelesEducacao.Core.Communication.Mediator;
using TelesEducacao.Core.DomainObjects;

namespace TelesEducacao.Alunos.Data;

public static class MediatorExtension
{
    public static async Task PublicarEventos<T>(this IMediatorHandler mediator, T context) where T : AlunosContext
    {
        var domainEntities = context.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.Eventos.Any())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.Eventos)
            .ToList();

        domainEntities.ForEach(entity => entity.Entity.LimparEventos());

        foreach (var domainEvent in domainEvents)
        {
            await mediator.PublicarEvento(domainEvent);
        }
    }
}