using TelesEducacao.Core.Data;

namespace TelesEducacao.Catalogo.Domain;

public interface ICursoRepository : IRepository<Curso>
{
    Task<Curso> ObterPorId(Guid id);

    Task<IEnumerable<Curso>> ObterTodos();

    Task Adicionar(Curso curso);

    Task Atualizar(Curso curso);

    Task Remover(Curso curso);
}