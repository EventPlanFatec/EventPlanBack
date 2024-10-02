using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanApp.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoDTO>>> GetEvents()
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
        public async Task<ActionResult<EventoDTO>> CreateEvent([FromBody] EventoDTO eventoDto)
        {
            var createdEvent = await _eventoService.Add(eventoDto);

            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.EventoId }, createdEvent);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventoDTO>> GetEventById(Guid id)
        {
            var evento = await _eventoService.GetById(id);

            if (evento == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            return Ok(evento);
        }
    }
}
