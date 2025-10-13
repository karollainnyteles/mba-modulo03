using Microsoft.EntityFrameworkCore;
using TelesEducacao.Catalogo.Domain;
using TelesEducacao.Core.Data;

namespace TelesEducacao.Catalogo.Data.Repository;

public class CursoRepository : ICursoRepository
{
    private readonly CatalogoContext _context;

    public CursoRepository(CatalogoContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<Curso> ObterPorId(Guid id)
    {
        return await _context.Cursos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Curso>> ObterTodos()
    {
        return await _context.Cursos.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Aula>> ObterAulas(Guid cursoId)
    {
        return await _context.Aulas.AsNoTracking()
            .Where(a => a.CursoId == cursoId)
            .ToListAsync();
    }

    public async Task<Aula> ObterAula(Guid aulaId)
    {
        return await _context.Aulas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == aulaId);
    }

    public void Adicionar(Curso curso)
    {
        _context.Cursos.Add(curso);
    }

    public void Atualizar(Curso curso)
    {
        _context.Cursos.Update(curso);
    }

    public void Remover(Curso curso)
    {
        _context.Cursos.Remove(curso);
    }

    public void AdicionarAula(Aula aula)
    {
        _context.Aulas.Add(aula);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}