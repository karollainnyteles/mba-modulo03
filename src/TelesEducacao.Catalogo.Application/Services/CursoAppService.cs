using AutoMapper;
using TelesEducacao.Conteudos.Application.Dtos;
using TelesEducacao.Conteudos.Domain;

namespace TelesEducacao.Conteudos.Application.Services;

public class CursoAppService : ICursoAppService
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IMapper _mapper;

    public CursoAppService(ICursoRepository cursoRepository, IMapper mapper)
    {
        _cursoRepository = cursoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CursoDto>> ObterTodos()
    {
        return _mapper.Map<IEnumerable<CursoDto>>(await _cursoRepository.ObterTodos());
    }

    public async Task<CursoDto> ObterPorId(Guid id)
    {
        return _mapper.Map<CursoDto>(await _cursoRepository.ObterPorId(id));
    }

    public async Task<IEnumerable<AulaDto>> ObterAulas(Guid cursoId)
    {
        return _mapper.Map<IEnumerable<AulaDto>>(await _cursoRepository.ObterAulas(cursoId));
    }

    public async Task<AulaDto> ObterAula(Guid aulaId)
    {
        return _mapper.Map<AulaDto>(await _cursoRepository.ObterAula(aulaId));
    }

    public Task Adicionar(CursoDto cursoDto)
    {
        var curso = _mapper.Map<Curso>(cursoDto);
        _cursoRepository.Adicionar(curso);

        return _cursoRepository.UnitOfWork.Commit();
    }

    public Task Atualizar(CursoDto cursoDto)
    {
        var curso = _mapper.Map<Curso>(cursoDto);
        _cursoRepository.Atualizar(curso);

        return _cursoRepository.UnitOfWork.Commit();
    }

    public async Task<Task<bool>> Remover(Guid id)
    {
        var curso = await _cursoRepository.ObterPorId(id);
        _cursoRepository.Remover(curso);
        return _cursoRepository.UnitOfWork.Commit();
    }

    public Task AdicionarAula(AulaDto aulaDto)
    {
        var aula = _mapper.Map<Aula>(aulaDto);
        _cursoRepository.AdicionarAula(aula);
        return _cursoRepository.UnitOfWork.Commit();
    }

    public async Task<Task<bool>> RemoverAula(Guid id)
    {
        var aula = await _cursoRepository.ObterAula(id);
        //TODO: Implementar remoção de aula
        //_cursoRepository.RemoverAula(aula);
        return _cursoRepository.UnitOfWork.Commit();
    }

    public void Dispose()
    {
        _cursoRepository.Dispose();
    }
}