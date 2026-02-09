using TelesEducacao.Core.Data;

namespace TelesEducacao.Pagamentos.Business;

public interface IPagamentoRepository : IRepository<Pagamento>
{
    void Adicionar(Pagamento pagamento);

    void AdicionarTransacao(Transacao transacao);
}