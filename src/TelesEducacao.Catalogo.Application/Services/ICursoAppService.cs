using TelesEducacao.Conteudos.Application.Dtos;

namespace TelesEducacao.Conteudos.Application.Services;

public interface ICursoAppService : IDisposable
{
    Task<IEnumerable<CursoDto>> ObterTodos();

    Task<CursoDto> ObterPorId(Guid id);

    Task<IEnumerable<AulaDto>> ObterAulas(Guid cursoId);

    Task<AulaDto> ObterAula(Guid aulaId);

    Task<Guid?> Adicionar(CursoDto cursoDto);

    Task Atualizar(CursoDto cursoDto);

    Task<bool> Remover(Guid id);

    Task AdicionarAula(AulaDto aulaDto);

    Task<bool> RemoverAula(Guid id);
}