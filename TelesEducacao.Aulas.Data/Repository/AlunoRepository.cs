using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Data;

namespace TelesEducacao.Alunos.Data.Repository;

public class AlunoRepository : IAlunoRepository
{
    private readonly AlunosContext _context;

    public AlunoRepository(AlunosContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public Task RegistrarAsync(Aluno aluno)
    {
        throw new NotImplementedException();
    }

    public Task<Aluno?> ObterPorUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Aluno>> ObterTodosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Guid?> AdicionarMatriculaAsync(Guid alunoId, Guid cursoId)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}