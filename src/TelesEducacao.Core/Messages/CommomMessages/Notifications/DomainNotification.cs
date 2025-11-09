using MediatR;

namespace TelesEducacao.Core.Messages.CommomMessages.Notifications;

public class DomainNotification : Message, INotification
{
    public string Key { get; private set; }
    public string Value { get; private set; }
    public DateTime Timestamp { get; private set; } = DateTime.Now;

    public DomainNotification(string key, string value, DateTime timestamp)
    {
        Key = key;
        Value = value;
        Timestamp = timestamp;
    }
}