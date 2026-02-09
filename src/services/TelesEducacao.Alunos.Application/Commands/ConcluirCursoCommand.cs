using MediatR;
using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Messages;

namespace TelesEducacao.Alunos.Application.Commands;

public class ConcluirCursoCommand : Command, IRequest
{
    public Guid MatriculaId { get; init; }

    public ConcluirCursoCommand(Guid matriculaId)
    {
        MatriculaId = matriculaId;
    }
}

public class ConcluirCursoCommandHandler : IRequestHandler<ConcluirCursoCommand, bool>
{
    private readonly IAlunoRepository _alunoRepository;

    public ConcluirCursoCommandHandler(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<bool> Handle(ConcluirCursoCommand request, CancellationToken cancellationToken)
    {
        await _alunoRepository.AlterarStatusMatriculaAsync(request.MatriculaId, MatriculaStatus.Concluida);

        await _alunoRepository.AdicionarCertificadoAsync(request.MatriculaId);
        return await _alunoRepository.UnitOfWork.Commit();
    }
}