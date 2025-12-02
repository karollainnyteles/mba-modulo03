using TelesEducacao.Core.Data;

namespace TelesEducacao.Alunos.Domain;

public interface IAlunoRepository : IRepository<Aluno>
{
    Task RegistrarAsync(string email, string senha);

    Task<Aluno?> ObterPorUserIdAsync(Guid userId);

    Task<List<Aluno>> ObterTodosAsync();

    Task<Guid?> AdicionarMatriculaAsync(Guid alunoId, Guid cursoId);
}