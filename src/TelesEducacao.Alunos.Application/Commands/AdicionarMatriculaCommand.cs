using FluentValidation;
using MediatR;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class AdicionarMatriculaCommand : Command, IRequest
{
    public Guid AlunoId { get; init; }
    public Guid CursoId { get; init; }

    public AdicionarMatriculaCommand(Guid alunoId, Guid cursoId)
    {
        AlunoId = alunoId;
        CursoId = cursoId;
    }

    public override bool EhValido()
    {
        var validator = new AdicionarMatriculaValidator();
        ValidationResult = validator.Validate(this);
        return ValidationResult.IsValid;
    }
}

public class AdicionarMatriculaValidator : AbstractValidator<AdicionarMatriculaCommand>
{
    public AdicionarMatriculaValidator()
    {
        RuleFor(c => c.AlunoId)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id do aluno é obrigatório.");

        RuleFor(c => c.CursoId)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id do curso é obrigatório.");
    }
}