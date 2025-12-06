using System.Text.Json.Serialization;
using FluentValidation.Results;
using MediatR;

namespace TelesEducacao.Core.Messages;

public class Command : Message, IRequest<bool>
{
    [JsonIgnore]
    public DateTime Timestamp { get; private set; }

    [JsonIgnore]
    public ValidationResult? ValidationResult { get; set; }

    public Command()
    {
        Timestamp = DateTime.Now;
    }

    public virtual bool EhValido()
    {
        throw new NotImplementedException();
    }
}