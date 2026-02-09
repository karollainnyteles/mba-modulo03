using MediatR;
using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class CriarAlunoCommandHandler : IRequestHandler<CriarAlunoCommand, bool>
{
    private readonly IAlunoRepository _alunoRepository;

    public CriarAlunoCommandHandler(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<bool> Handle(CriarAlunoCommand request, CancellationToken cancellationToken)
    {
        if (!ValidarComando(request)) return false;

        var aluno = new Aluno(request.UserId);

        _alunoRepository.CriarAsync(aluno);

        return await _alunoRepository.UnitOfWork.Commit();
    }

    private bool ValidarComando(Command command)
    {
        if (command.EhValido()) return true;

        foreach (var error in command.ValidationResult.Errors)
        {
            //lancar evento de erro
        }

        return false;
    }
}