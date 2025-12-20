using TelesEducacao.Alunos.Domain;

namespace TelesEducacao.Alunos.Application.Queries.Dtos;

public class MatriculaDto
{
    public Guid Id { get; init; }
    public Guid CursoId { get; init; }

    public MatriculaStatus MatriculaStatus { get; init; }
}