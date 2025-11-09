using TelesEducacao.Core.Data;

namespace TelesEducacao.Alunos.Domain;

public interface IAlunoRepository : IRepository<Aluno>
{
    Task RegistrarAsync(Aluno aluno);

    Task<Aluno?> ObterPorUserIdAsync(Guid userId);

    Task<List<Aluno>> ObterTodosAsync();

    Task<Guid?> AdicionarMatriculaAsync(Guid alunoId, Guid cursoId);
}