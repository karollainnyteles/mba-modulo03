using TelesEducacao.Core.Messages;

namespace TelesEducacao.Core.DomainObjects;

public abstract class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime DataCadastro { get; init; } = DateTime.Now;

    private List<Event> _eventos = new();
    public IReadOnlyCollection<Event> Eventos => _eventos.AsReadOnly();

    protected void AdicionarEvento(Event eventItem)
    {
        _eventos.Add(eventItem);
    }

    protected void RemoverEvento(Event eventItem)
    {
        _eventos.Remove(eventItem);
    }

    public void LimparEventos()
    {
        _eventos.Clear();
    }
}