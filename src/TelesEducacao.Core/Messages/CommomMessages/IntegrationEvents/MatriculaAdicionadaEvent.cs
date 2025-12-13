namespace TelesEducacao.Core.Messages.CommomMessages.IntegrationEvents;

public class MatriculaAdicionadaEvent : IntegrationEvent
{
    public Guid AlunoId { get; init; }

    public Guid CursoId { get; init; }

    public string NomeCartao { get; init; }

    public string NumeroCartao { get; init; }

    public string ExpiracaoCartao { get; init; }

    public string CvvCartao { get; init; }

    public MatriculaAdicionadaEvent(Guid alunoId, Guid cursoId, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
    {
        AlunoId = alunoId;
        CursoId = cursoId;
        NomeCartao = nomeCartao;
        NumeroCartao = numeroCartao;
        ExpiracaoCartao = expiracaoCartao;
        CvvCartao = cvvCartao;
    }
}