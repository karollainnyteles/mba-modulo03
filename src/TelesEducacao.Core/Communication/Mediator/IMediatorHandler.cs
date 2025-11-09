using TelesEducacao.Core.Messages;

namespace TelesEducacao.Core.Communication.Mediator;

public interface IMediatorHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;

    Task EnviarComando<T>(T command) where T : Command;
}