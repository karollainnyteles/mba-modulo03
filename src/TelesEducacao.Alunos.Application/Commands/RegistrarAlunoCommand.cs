using FluentValidation;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class RegistrarAlunoCommand : Command
{
    public string Nome { get; init; }
    public string Email { get; init; }

    public RegistrarAlunoCommand(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }

    public override bool EhValido()
    {
        var validator = new RegistrarAlunoValidator();
        ValidationResult = validator.Validate(this);
        return ValidationResult.IsValid;
    }
}

public class RegistrarAlunoValidator : AbstractValidator<RegistrarAlunoCommand>
{
    public RegistrarAlunoValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
            .WithMessage("O nome do aluno é obrigatório.")
            .MaximumLength(100)
            .WithMessage("O nome do aluno não pode exceder 100 caracteres.");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("O email do aluno é obrigatório.")
            .EmailAddress()
            .WithMessage("O email do aluno é inválido.");
    }
}