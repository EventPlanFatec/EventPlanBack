using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly IIngressoService _ingressoService;

        public TicketsController(IIngressoService ingressoService)
        {
            _ingressoService = ingressoService;
        }

        // POST: /api/tickets
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] IngressoDto ingressoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _ingressoService.CreateTicket(ingressoDto);

                if (result)
                {
                    return Ok("Ingresso criado com sucesso.");
                }
                return BadRequest("Erro ao criar o ingresso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetAllTickets()
        {
            var tickets = await _ingressoService.GetAllTicketsAsync();
            return Ok(tickets);
        }
    }
    
}

