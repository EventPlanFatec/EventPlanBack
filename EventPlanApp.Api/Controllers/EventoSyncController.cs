using EventPlanApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventPlanApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoSyncController : ControllerBase
    {
        private readonly EventoSyncService _eventoSyncService;

        public EventoSyncController(EventoSyncService eventoSyncService)
        {
            _eventoSyncService = eventoSyncService;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncEventos()
        {
            try
            {
                await _eventoSyncService.SyncEventosFromFirebaseToSqlServerAsync();
                return Ok("Eventos sincronizados com sucesso!");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Erro ao sincronizar eventos: {ex.Message}");
            }
        }
    }
}
