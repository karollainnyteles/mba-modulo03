using TelesEducacao.Core.Messages;

namespace TelesEducacao.Core.Bus;

public interface IMediatrHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
}