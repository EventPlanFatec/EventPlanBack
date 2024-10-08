using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.API.Controllers
{
    [Route("api/waitlists")]
    [ApiController]
    public class ListaEsperaController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public ListaEsperaController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost("{eventoId}")]
        public async Task<IActionResult> InscreverNaListaEspera(int eventoId, [FromBody] InscricaoListaEsperaDTO inscricao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            inscricao.EventoId = eventoId;

            var resultado = await _eventoService.InscreverNaListaDeEspera(eventoId, inscricao);
            if (resultado)
            {
                return Ok("Inscrição na lista de espera realizada com sucesso.");
            }

            return NotFound("Evento não encontrado ou já está cheio.");
        }

        [HttpDelete("{eventoId}/usuario/{usuarioId}")]
        public async Task<IActionResult> RemoverInscricao(int eventoId, int usuarioId)
        {
            try
            {
                await _eventoService.RemoverInscricaoAsync(usuarioId, eventoId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
