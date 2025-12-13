using TelesEducacao.Core.Data;

namespace TelesEducacao.Alunos.Domain;

public interface IAlunoRepository : IRepository<Aluno>
{
    void CriarAsync(Aluno aluno);

    Task<Aluno?> ObterPorUserIdAsync(Guid userId);

    Task<IEnumerable<Aluno>> ObterTodosAsync();

    void AdicionarMatriculaAsync(Guid alunoId, Guid cursoId);

    Task<IEnumerable<Matricula>> ObterMatriculasPorAlunoIdAsync(Guid alunoId);
}