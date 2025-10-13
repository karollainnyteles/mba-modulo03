using TelesEducacao.Catalogo.Application.Dtos;

namespace TelesEducacao.Catalogo.Application.Services;

public interface ICursoAppService : IDisposable
{
    Task<IEnumerable<CursoDto>> ObterTodos();

    Task<CursoDto> ObterPorId(Guid id);

    Task<IEnumerable<AulaDto>> ObterAulas(Guid cursoId);

    Task<AulaDto> ObterAula(Guid aulaId);

    Task Adicionar(CursoDto cursoDto);

    Task Atualizar(CursoDto cursoDto);

    Task<Task<bool>> Remover(Guid id);

    Task AdicionarAula(AulaDto aulaDto);

    Task<Task<bool>> RemoverAula(Guid id);
}