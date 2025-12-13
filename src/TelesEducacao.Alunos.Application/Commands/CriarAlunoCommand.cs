using FluentValidation;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class CriarAlunoCommand : Command
{
    public Guid UserId { get; init; }

    public CriarAlunoCommand(Guid userId)
    {
        UserId = userId;
    }

    public override bool EhValido()
    {
        var validator = new CriarAlunoValidator();
        ValidationResult = validator.Validate(this);
        return ValidationResult.IsValid;
    }
}

public class CriarAlunoValidator : AbstractValidator<CriarAlunoCommand>
{
    public CriarAlunoValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty();
    }
}