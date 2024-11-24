using System.Threading.Tasks;
using EventPlanApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/taxaservico")]
    public class TaxaServicoConfigController : ControllerBase
    {
        private readonly ITaxaServicoConfigService _taxaServicoConfigService;

        public TaxaServicoConfigController(ITaxaServicoConfigService taxaServicoConfigService)
        {
            _taxaServicoConfigService = taxaServicoConfigService;
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
    }
}
