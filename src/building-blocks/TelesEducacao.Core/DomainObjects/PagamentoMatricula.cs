namespace TelesEducacao.Core.DomainObjects;

public class PagamentoMatricula
{
    public Guid AlunoId { get; set; }
    public Guid CursoId { get; set; }
    public Guid MatriculaId { get; set; }
    public decimal Valor { get; set; }
    public string NomeCartao { get; set; }
    public string NumeroCartao { get; set; }
    public string ExpiracaoCartao { get; set; }
    public string CvvCartao { get; set; }
}