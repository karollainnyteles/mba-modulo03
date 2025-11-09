using MediatR;
using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class AdicionarMatriculaCommandHandler : IRequestHandler<AdicionarMatriculaCommand, bool>
{
    private readonly IAlunoRepository _alunoRepository;

    public AdicionarMatriculaCommandHandler(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<bool> Handle(AdicionarMatriculaCommand request, CancellationToken cancellationToken)
    {
        if (!ValidarComando(request)) return false;

        var matriculaId = await _alunoRepository.AdicionarMatriculaAsync(request.AlunoId, request.CursoId);

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