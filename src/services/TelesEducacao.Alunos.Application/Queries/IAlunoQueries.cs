using TelesEducacao.Alunos.Application.Queries.Dtos;
using TelesEducacao.Alunos.Domain;

namespace TelesEducacao.Alunos.Application.Queries;

public interface IAlunoQueries
{
    Task<IEnumerable<AlunoDto>> ObterTodos();

    Task<AlunoDto> ObterPorId(Guid id);

    Task<IEnumerable<MatriculaDto>> ObterMatriculasPorAlunoId(Guid alunoId);

    Task<MatriculaDto> ObterMatriculaPorId(Guid matriculaId);

    Task<IEnumerable<AulaConluida>> ObterAulasConcluidasPorMatriculaId(Guid matriculaId);
}