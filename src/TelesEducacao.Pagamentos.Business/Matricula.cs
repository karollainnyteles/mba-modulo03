namespace TelesEducacao.Pagamentos.Business;

public class Matricula
{
    public Guid Id { get; set; }
    public Guid CursoId { get; set; }
    public decimal Valor { get; set; }
}