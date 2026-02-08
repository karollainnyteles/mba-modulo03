using Microsoft.AspNetCore.Mvc;
using TelesEducacao.Core.DomainObjects;
using TelesEducacao.Pagamentos.Business;
using Microsoft.EntityFrameworkCore;
using TelesEducacao.Pagamentos.Data;


namespace TelesEducacao.Pagamentos.API.Controllers;

[ApiController]
[Route("pagamentos")]
public class PagamentosController : ControllerBase
{
    private readonly IPagamentoService _pagamentoService;

    public PagamentosController(IPagamentoService pagamentoService)
    {
        _pagamentoService = pagamentoService;
    }

    // DTO de entrada da API
    public class RealizarPagamentoMatriculaRequest
    {
        public Guid MatriculaId { get; set; }
        public Guid AlunoId { get; set; }
        public decimal Valor { get; set; }

        public string NomeCartao { get; set; } = string.Empty;
        public string NumeroCartao { get; set; } = string.Empty;
        public string ExpiracaoCartao { get; set; } = string.Empty;
        public string CvvCartao { get; set; } = string.Empty;
    }

  
    public class RealizarPagamentoMatriculaResponse
    {
        public Guid PagamentoId { get; set; }
        public Guid TransacaoId { get; set; }
        public StatusTransacao Status { get; set; }
    }

 
    /// Realiza o pagamento de uma matrícula   
    [HttpPost("matricula")]
    public async Task<ActionResult<RealizarPagamentoMatriculaResponse>> RealizarPagamentoMatricula(
        [FromBody] RealizarPagamentoMatriculaRequest request)
    {
        if (request.MatriculaId == Guid.Empty)
            return BadRequest("MatriculaId é obrigatório.");

        if (request.AlunoId == Guid.Empty)
            return BadRequest("AlunoId é obrigatório.");

        if (request.Valor <= 0)
            return BadRequest("Valor deve ser maior que zero.");

        var pagamentoMatricula = new PagamentoMatricula
        {
            MatriculaId = request.MatriculaId,
            AlunoId = request.AlunoId,
            Valor = request.Valor,
            NomeCartao = request.NomeCartao,
            NumeroCartao = request.NumeroCartao,
            ExpiracaoCartao = request.ExpiracaoCartao,
            CvvCartao = request.CvvCartao
        };

        var transacao = await _pagamentoService.RealizarPagamentoMatricula(pagamentoMatricula);

        return Ok(new RealizarPagamentoMatriculaResponse
        {
            PagamentoId = transacao.PagamentoId,
            TransacaoId = transacao.Id,
            Status = transacao.StatusTransacao
        });
    }


    public class StatusPagamentoResponse
    {
        public Guid MatriculaId { get; set; }
        public Guid PagamentoId { get; set; }
        public Guid TransacaoId { get; set; }
        public StatusTransacao Status { get; set; }
        public decimal Total { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    [HttpGet("matricula/{matriculaId:guid}/status")]
    public async Task<ActionResult<StatusPagamentoResponse>> ConsultarStatusPorMatricula(
        Guid matriculaId,
        [FromServices] PagamentosContext context)
    {
        if (matriculaId == Guid.Empty)
            return BadRequest("matriculaId inválido.");

        var transacao = await context.Transacoes
            .AsNoTracking()
            .Where(t => t.MatriculaId == matriculaId)
            .OrderByDescending(t => t.DataCadastro)
            .FirstOrDefaultAsync();

        if (transacao is null)
            return NotFound("Nenhuma transação encontrada para esta matrícula.");

        return Ok(new StatusPagamentoResponse
        {
            MatriculaId = transacao.MatriculaId,
            PagamentoId = transacao.PagamentoId,
            TransacaoId = transacao.Id,
            Status = transacao.StatusTransacao,
            Total = transacao.Total,
            DataCadastro = transacao.DataCadastro
        });
    }

}
