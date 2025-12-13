using Microsoft.EntityFrameworkCore;
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

    public void CriarAsync(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
    }

    public async Task<Aluno?> ObterPorUserIdAsync(Guid userId)
    {
        return await _context.Alunos.FirstOrDefaultAsync(a => a.UserId == userId);
    }

    public async Task<IEnumerable<Aluno>> ObterTodosAsync()
    {
        return await _context.Alunos.ToListAsync();
    }

    public void AdicionarMatriculaAsync(Guid alunoId, Guid cursoId)
    {
        var matricula = new Matricula(alunoId, cursoId);
        _context.Add(matricula);
    }

    public async Task<IEnumerable<Matricula>> ObterMatriculasPorAlunoIdAsync(Guid alunoId)
    {
        return await _context.Matriculas
             .AsNoTracking()
             .Where(m => m.AlunoId == alunoId)
             .ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}