using Microsoft.EntityFrameworkCore;
using TelesEducacao.Catalogo.Domain;

namespace TelesEducacao.Catalogo.Data.Repository;

public class CursoRepository : ICursoRepository
{
    private readonly CatalogoContext _context;

    public CursoRepository(CatalogoContext context)
    {
        _context = context;
    }

    public async Task<Curso> ObterPorId(Guid id)
    {
        return await _context.Cursos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Curso>> ObterTodos()
    {
        return await _context.Cursos.AsNoTracking().ToListAsync();
    }

    public async Task Adicionar(Curso curso)
    {
        _context.Cursos.Add(curso);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Curso curso)
    {
        _context.Cursos.Update(curso);
        await _context.SaveChangesAsync();
    }

    public async Task Remover(Curso curso)
    {
        _context.Cursos.Remove(curso);
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}