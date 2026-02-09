using MediatR;
using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class AtivarMatriculaCommand : Command
{
    public Guid MatriculaId { get; init; }

    public AtivarMatriculaCommand(Guid matriculaId)
    {
        MatriculaId = matriculaId;
    }
}

public class AtivarMatriculaCommandHandler : IRequestHandler<AtivarMatriculaCommand, bool>
{
    private readonly IAlunoRepository _alunoRepository;

    public AtivarMatriculaCommandHandler(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<bool> Handle(AtivarMatriculaCommand request, CancellationToken cancellationToken)
    {
        await _alunoRepository.AlterarStatusMatriculaAsync(request.MatriculaId, MatriculaStatus.Ativa);
        return await _alunoRepository.UnitOfWork.Commit();
    }
}