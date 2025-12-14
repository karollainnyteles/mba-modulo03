using TelesEducacao.Core.Communication.Mediator;
using TelesEducacao.Core.DomainObjects;
using TelesEducacao.Core.Messages.CommomMessages.IntegrationEvents;
using TelesEducacao.Core.Messages.CommomMessages.Notifications;

namespace TelesEducacao.Pagamentos.Business;

public class PagamentoService : IPagamentoService
{
    private readonly IPagamentoCartaoCreditoFacade _pagamentoCartaoCreditoFacade;
    private readonly IPagamentoRepository _pagamentoRepository;
    private readonly IMediatorHandler _mediatorHandler;

    public PagamentoService(IPagamentoCartaoCreditoFacade pagamentoCartaoCreditoFacade,
                            IPagamentoRepository pagamentoRepository,
                            IMediatorHandler mediatorHandler)
    {
        _pagamentoCartaoCreditoFacade = pagamentoCartaoCreditoFacade;
        _pagamentoRepository = pagamentoRepository;
        _mediatorHandler = mediatorHandler;
    }

    public async Task<Transacao> RealizarPagamentoMatricula(PagamentoMatricula pagamentoMatricula)
    {
        var pagamento = new Pagamento
        {
            Valor = pagamentoMatricula.Valor,
            DadosCartao = new DadosCartao
            {
                Nome = pagamentoMatricula.NomeCartao,
                Numero = pagamentoMatricula.NumeroCartao,
                Expiracao = pagamentoMatricula.ExpiracaoCartao,
                Cvv = pagamentoMatricula.CvvCartao
            },
            MatriculaId = pagamentoMatricula.MatriculaId
        };

        var transacao = _pagamentoCartaoCreditoFacade.RealizarPagamento(pagamento);

        if (transacao.StatusTransacao == StatusTransacao.Pago)
        {
            pagamento.AdicionarEvento(new PagamentoRealizadoEvent(pagamento.MatriculaId, pagamentoMatricula.AlunoId, transacao.PagamentoId, transacao.Id, pagamentoMatricula.Valor));

            _pagamentoRepository.Adicionar(pagamento);
            _pagamentoRepository.AdicionarTransacao(transacao);

            await _pagamentoRepository.UnitOfWork.Commit();
            return transacao;
        }

        await _mediatorHandler.PublicarNotificacao(new DomainNotification("pagamento", "A operadora recusou o pagamento"));
        await _mediatorHandler.PublicarEvento(new PagamentoRecusadoEvent(pagamento.MatriculaId, pagamentoMatricula.AlunoId, transacao.PagamentoId, transacao.Id, pagamentoMatricula.Valor));

        return transacao;
    }
}