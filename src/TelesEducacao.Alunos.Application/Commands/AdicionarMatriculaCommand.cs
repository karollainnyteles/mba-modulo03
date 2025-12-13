using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class AdicionarMatriculaCommand : Command, IRequest
{
    public Guid AlunoId { get; init; }
    public Guid CursoId { get; init; }

    public string NomeCartao { get; init; }

    public string NumeroCartao { get; init; }

    public string ExpiracaoCartao { get; init; }

    public string CvvCartao { get; init; }

    public AdicionarMatriculaCommand(Guid alunoId, Guid cursoId, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
    {
        AlunoId = alunoId;
        CursoId = cursoId;
        NomeCartao = nomeCartao;
        NumeroCartao = numeroCartao;
        ExpiracaoCartao = expiracaoCartao;
        CvvCartao = cvvCartao;
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

        RuleFor(c => c.NomeCartao)
            .NotEmpty()
            .WithMessage("O nome no cartão é obrigatório.");

        RuleFor(c => c.NumeroCartao)
            .NotEmpty()
            .WithMessage("O número do cartão é obrigatório.");

        RuleFor(c => c.ExpiracaoCartao)
            .NotEmpty()
            .WithMessage("A data de expiração do cartão é obrigatória.");

        RuleFor(c => c.CvvCartao)
            .NotEmpty()
            .WithMessage("O CVV do cartão é obrigatório.");
    }
}