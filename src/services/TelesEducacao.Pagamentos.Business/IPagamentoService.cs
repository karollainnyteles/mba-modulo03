using TelesEducacao.Core.DomainObjects;

namespace TelesEducacao.Pagamentos.Business;

public interface IPagamentoService
{
    Task<Transacao> RealizarPagamentoMatricula(PagamentoMatricula pagamentoMatricula);
}