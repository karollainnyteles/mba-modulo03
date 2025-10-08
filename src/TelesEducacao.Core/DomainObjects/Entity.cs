namespace TelesEducacao.Core.DomainObjects;

public abstract class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime DataCadastro { get; init; } = DateTime.Now;
}