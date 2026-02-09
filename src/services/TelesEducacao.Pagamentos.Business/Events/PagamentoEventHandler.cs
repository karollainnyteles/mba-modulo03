using MediatR;
using TelesEducacao.Core.DomainObjects;
using TelesEducacao.Core.Messages.CommomMessages.IntegrationEvents;

namespace TelesEducacao.Pagamentos.Business.Events;

public class PagamentoEventHandler : INotificationHandler<MatriculaAdicionadaEvent>
{
    private readonly IPagamentoService _pagamentoService;

    public PagamentoEventHandler(IPagamentoService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    public async Task Handle(MatriculaAdicionadaEvent notification, CancellationToken cancellationToken)
    {
        var pagamentoMatricula = new PagamentoMatricula
        {
            MatriculaId = notification.MatriculaId,
            AlunoId = notification.AlunoId,
            CursoId = notification.CursoId,
            NomeCartao = notification.NomeCartao,
            NumeroCartao = notification.NumeroCartao,
            ExpiracaoCartao = notification.ExpiracaoCartao,
            CvvCartao = notification.CvvCartao,
            Valor = notification.Valor
        };

        await _pagamentoService.RealizarPagamentoMatricula(pagamentoMatricula);
    }
}