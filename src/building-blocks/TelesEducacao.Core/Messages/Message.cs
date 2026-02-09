using System.Text.Json.Serialization;

namespace TelesEducacao.Core.Messages;

public abstract class Message
{
    [JsonIgnore]
    public string MessageType { get; protected set; }
    [JsonIgnore]
    public Guid AggregateId { get; protected set; }

    protected Message()
    {
        MessageType = GetType().Name;
    }
}