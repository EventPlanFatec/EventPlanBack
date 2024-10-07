using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        private readonly IMapper _mapper;

        public EventoController(IEventoService eventoService, IMapper mapper)
        {
            _eventoService = eventoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoDto>>> GetEvents()
        {
            var events = await _eventoService.GetAll();

            if (events == null || !events.Any())
            {
                return NotFound("No events found.");
            }

            return Ok(events.Select(e => new
            {
                e.NomeEvento,
                e.DataInicio,
                e.DataFim
            }));
        }

        [HttpPost]
        public async Task<ActionResult<EventoDto>> CreateEvent([FromBody] EventoDto eventoDto)
        {
            var createdEvent = await _eventoService.Add(eventoDto);
            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.EventoId }, createdEvent);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventoDto>> GetEventById(int id)
        {
            var evento = await _eventoService.GetById(id);

            if (evento == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            return Ok(evento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EventoDto>> UpdateEvent(int id, [FromBody] EventoDto eventoDto)
        {
            var existingEvent = await _eventoService.GetById(id);
            if (existingEvent == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            var updatedEvent = await _eventoService.Update(id, eventoDto);
            return Ok(updatedEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var existingEvent = await _eventoService.GetById(id);
            if (existingEvent == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            var deleted = await _eventoService.Delete(id);
            if (!deleted)
            {
                return BadRequest("Failed to delete the event.");
            }

            return NoContent();
        }

        [HttpPost("{eventoId}/lista-espera")]
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
