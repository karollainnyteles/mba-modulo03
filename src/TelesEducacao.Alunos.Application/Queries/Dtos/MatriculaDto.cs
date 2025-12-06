using TelesEducacao.Alunos.Domain;

namespace TelesEducacao.Alunos.Application.Queries.Dtos;

public class MatriculaDto
{
    public Guid CursoId { get; init; }

    public MatriculaStatus MatriculaStatus { get; init; }
}