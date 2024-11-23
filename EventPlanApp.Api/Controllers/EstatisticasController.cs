using EventPlanApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/calculo-taxa-de-cancelamento")]
    public class EstatisticasController : ControllerBase
    {
        private readonly EventoEstatisticasService _estatisticasService;

        public EstatisticasController(EventoEstatisticasService estatisticasService)
        {
            _estatisticasService = estatisticasService;
        }

        [HttpGet("{eventoId}/taxa-cancelamento")]
        public async Task<IActionResult> ObterTaxaCancelamento(int eventoId)
        {
            try
            {
                var estatisticas = await _estatisticasService.ObterEstatisticasEventoAsync(eventoId);
                return Ok(estatisticas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }

}
