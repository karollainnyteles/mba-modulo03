namespace TelesEducacao.Alunos.Domain;

public interface IAlunoRepository
{
    Task RegistrarAsync(Aluno aluno);
}