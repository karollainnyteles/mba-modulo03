namespace TelesEducacao.Pagamentos.Business;

public interface IPagamentoCartaoCreditoFacade
{
    Transacao RealizarPagamento(Pagamento pagamento);
}