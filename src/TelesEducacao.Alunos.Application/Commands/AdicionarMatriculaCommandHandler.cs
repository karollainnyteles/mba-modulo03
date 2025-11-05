using MediatR;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class AdicionarMatriculaCommandHandler : IRequestHandler<AdicionarMatriculaCommand, bool>
{
    public async Task<bool> Handle(AdicionarMatriculaCommand request, CancellationToken cancellationToken)
    {
        if (!ValidarComando(request)) return false;
        //lógica de adicionar matrícula

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