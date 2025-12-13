using TelesEducacao.Core.DomainObjects;

namespace TelesEducacao.Pagamentos.Business;

public interface IPagamentoService
{
    Task<Transacao> RealizarPagamentoPedido(PagamentoMatricula pagamentoMatricula);
}