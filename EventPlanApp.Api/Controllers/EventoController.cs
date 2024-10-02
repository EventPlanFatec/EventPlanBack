using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet("events")]
        public async Task<ActionResult<IEnumerable<EventoDTO>>> GetEvents()
        {
            var events = await _eventoService.GetAll();

            if (events == null || !events.Any())
            {
                return NotFound("No events found.");
            }

            var formattedEvents = events.Select(e => new
            {
                nome = e.Nome,
                dataInicio = e.DataInicio,
                dataFim = e.DataFim,
                local = e.Local,
                descricao = e.Descricao 
            });

            return Ok(formattedEvents);
        }
    }
}
