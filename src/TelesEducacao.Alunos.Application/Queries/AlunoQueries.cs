using AutoMapper;
using TelesEducacao.Alunos.Application.Queries.Dtos;
using TelesEducacao.Alunos.Domain;

namespace TelesEducacao.Alunos.Application.Queries;

public class AlunoQueries : IAlunoQueries
{
    private readonly IMapper _mapper;
    private readonly IAlunoRepository _alunoRepository;

    public AlunoQueries(IAlunoRepository alunoRepository, IMapper mapper)
    {
        _alunoRepository = alunoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AlunoDto>> ObterTodos()
    {
        var alunos = await _alunoRepository.ObterTodosAsync();
        return _mapper.Map<IEnumerable<AlunoDto>>(alunos);
    }

    public async Task<AlunoDto> ObterPorId(Guid id)
    {
        var aluno = await _alunoRepository.ObterPorUserIdAsync(id);
        return _mapper.Map<AlunoDto>(aluno);
    }

    public async Task<IEnumerable<MatriculaDto>> ObterMatriculasPorAlunoId(Guid alunoId)
    {
        var matriculas = await _alunoRepository.ObterMatriculasPorAlunoIdAsync(alunoId);
        return _mapper.Map<IEnumerable<MatriculaDto>>(matriculas);
    }
}