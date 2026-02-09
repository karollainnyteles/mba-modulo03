using TelesEducacao.Core.DomainObjects;

namespace TelesEducacao.Alunos.Domain;

public class Aluno : Entity, IAggregateRoot
{
    public Guid UserId { get; private set; }

    public bool Ativo { get; private set; } = true;

    private readonly List<Matricula> _matriculas;
    public IReadOnlyCollection<Matricula> Matriculas => _matriculas;

    public Aluno(Guid userId)
    {
        UserId = userId;
        _matriculas = new List<Matricula>();
    }

    protected Aluno()
    {
        _matriculas = new List<Matricula>();
    }

    public void Ativar()
    {
        Ativo = true;
    }

    public void Desativar()
    {
        Ativo = false;
    }

    public void AdicionarMatricula(Matricula matricula)
    {
        _matriculas.Add(matricula);
    }
}