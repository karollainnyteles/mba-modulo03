using MediatR;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class RegistrarAlunoCommandHandler : IRequestHandler<RegistrarAlunoCommand, bool>
{
    public async Task<bool> Handle(RegistrarAlunoCommand request, CancellationToken cancellationToken)
    {
        if (!ValidarComando(request)) return false;
        //lógica de registrar aluno

        return true;
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