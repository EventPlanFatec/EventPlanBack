using System.Threading.Tasks;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/taxaservico")]
    public class TaxaServicoConfigController : ControllerBase
    {
        private readonly ITaxaServicoConfigService _taxaServicoConfigService;
        private readonly IIngressoRepository _ingressoRepository;
        private readonly IPurchaseRequest _purchaseRequest;

        public TaxaServicoConfigController(ITaxaServicoConfigService taxaServicoConfigService, IIngressoRepository ingressoRepository, IPurchaseRequest purchaseRequest)
        {
            _taxaServicoConfigService = taxaServicoConfigService;
            _ingressoRepository = ingressoRepository;
            _purchaseRequest = purchaseRequest;
        }

        [HttpPost("configurar")]
        public async Task<IActionResult> ConfigurarTaxaServico(int eventoId, decimal? taxaFixa, decimal? taxaPercentual)
        {
            try
            {
                await _taxaServicoConfigService.AdicionarOuAtualizarTaxaAsync(eventoId, taxaFixa, taxaPercentual);
                return Ok("Taxa de serviço configurada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("gerar-resumo-compra")]
        public async Task<IActionResult> GerarResumoCompra([FromBody] CompraRequestModel compraRequest)
        {
            try
            {
                // Obtém os ingressos pelo repositório
                var ingressos = await _ingressoRepository.ObterIngressosPorIdsAsync(compraRequest.IngressoIds);

                if (ingressos == null || !ingressos.Any())
                {
                    return NotFound("Nenhum ingresso encontrado para os IDs fornecidos.");
                }

                // Gera o resumo da compra
                var resumoCompra = await _purchaseRequest.GerarResumoCompra(compraRequest.EventoId, ingressos);

                return Ok(resumoCompra);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar o pedido: {ex.Message}");
            }
        }
    }
}
