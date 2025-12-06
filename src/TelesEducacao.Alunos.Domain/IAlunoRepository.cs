using TelesEducacao.Core.Data;

namespace TelesEducacao.Alunos.Domain;

public interface IAlunoRepository : IRepository<Aluno>
{
    Task RegistrarAsync(string email, string senha);

    Task<Aluno?> ObterPorUserIdAsync(Guid userId);

    Task<IEnumerable<Aluno>> ObterTodosAsync();

    void AdicionarMatriculaAsync(Guid alunoId, Guid cursoId);

    Task<IEnumerable<Matricula>> ObterMatriculasPorAlunoIdAsync(Guid alunoId);
}