namespace TelesEducacao.Pagamentos.Business;

public interface IPagamentoCartaoCreditoFacade
{
    Transacao RealizarPagamento(Matricula matricula, Pagamento pagamento);
}