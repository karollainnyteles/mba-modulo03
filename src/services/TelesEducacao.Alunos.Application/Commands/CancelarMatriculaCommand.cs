using MediatR;
using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class CancelarMatriculaCommand : Command
{
    public Guid MatriculaId { get; init; }

    public CancelarMatriculaCommand(Guid matriculaId)
    {
        MatriculaId = matriculaId;
    }
}

public class CancelarMatriaculaCommandHandler : IRequestHandler<CancelarMatriculaCommand, bool>
{
    private readonly IAlunoRepository _alunoRepository;

    public CancelarMatriaculaCommandHandler(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<bool> Handle(CancelarMatriculaCommand request, CancellationToken cancellationToken)
    {
        await _alunoRepository.AlterarStatusMatriculaAsync(request.MatriculaId, MatriculaStatus.Cancelada);
        return await _alunoRepository.UnitOfWork.Commit();
    }
}