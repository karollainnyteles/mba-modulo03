using TelesEducacao.Alunos.Application.Queries.Dtos;
using TelesEducacao.Alunos.Domain;

namespace TelesEducacao.Alunos.Application.Queries;

public class AlunoQueries : IAlunoQueries
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunoQueries(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<IEnumerable<AlunoDto>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public async Task<AlunoDto> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }
}