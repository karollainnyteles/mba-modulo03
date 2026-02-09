namespace TelesEducacao.Alunos.Application.Queries.Dtos;

public class AlunoDto
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public bool Ativo { get; init; }
}