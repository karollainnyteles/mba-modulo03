using MediatR;
using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class RegistrarAlunoCommandHandler : IRequestHandler<RegistrarAlunoCommand, bool>
{
    private readonly IAlunoRepository _alunoRepository;

    public RegistrarAlunoCommandHandler(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<bool> Handle(RegistrarAlunoCommand request, CancellationToken cancellationToken)
    {
        if (!ValidarComando(request)) return false;

        await _alunoRepository.RegistrarAsync(request.Email, request.Senha);

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