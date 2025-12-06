using TelesEducacao.Alunos.Application.Queries.Dtos;

namespace TelesEducacao.Alunos.Application.Queries;

public interface IAlunoQueries
{
    Task<IEnumerable<AlunoDto>> ObterTodos();

    Task<AlunoDto> ObterPorId(Guid id);

    Task<IEnumerable<MatriculaDto>> ObterMatriculasPorAlunoId(Guid alunoId);
}