using FluentValidation.Results;
using MediatR;

namespace TelesEducacao.Core.Messages;

public class Command : Message, IRequest<bool>
{
    public DateTime Timestamp { get; private set; }
    public ValidationResult ValidationResult { get; set; }

    public Command()
    {
        Timestamp = DateTime.Now;
    }

    public virtual bool EhValido()
    {
        throw new NotImplementedException();
    }
}