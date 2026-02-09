using TelesEducacao.Core.DomainObjects;

namespace TelesEducacao.Core.Data;

// um repositório por agregado
public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}