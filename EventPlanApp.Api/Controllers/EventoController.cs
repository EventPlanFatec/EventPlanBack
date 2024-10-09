using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public EventoController(IEventoService eventoService, IMapper mapper, IEmailService emailService)
        {
            _eventoService = eventoService;
            _mapper = mapper;
            _emailService = emailService; 
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
            if (eventoDto.IsPrivate)
            {
                if (string.IsNullOrEmpty(eventoDto.Senha))
                {
                    return BadRequest("A senha é obrigatória para eventos privados.");
                }

                eventoDto.Senha = _eventoService.HashPassword(eventoDto.Senha);
            }

            var createdEvent = await _eventoService.Add(eventoDto);

            if (eventoDto.EmailsConvidados != null && eventoDto.EmailsConvidados.Count > 0)
            {
                var subject = $"Convite para o evento: {eventoDto.NomeEvento}";
                var body = $"Você está convidado para o evento '{eventoDto.NomeEvento}' que ocorrerá em {eventoDto.DataInicio}.";

                foreach (var email in eventoDto.EmailsConvidados)
                {
                    var mensagemEmail = new MensagemEmail
                    {
                        Destinatario = email,
                        Assunto = subject,
                        Conteudo = body
                    };

                    await _emailService.SendEmailAsync(mensagemEmail);
                }
            }

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

        [HttpPut("{id}/senha")]
        public async Task<IActionResult> UpdateEventPassword(int id, [FromBody] string novaSenha)
        {
            if (string.IsNullOrEmpty(novaSenha))
            {
                return BadRequest("A nova senha é obrigatória.");
            }

            var resultado = await _eventoService.UpdateEventPassword(id, novaSenha);
            if (!resultado)
            {
                return NotFound($"Evento com ID {id} não encontrado.");
            }

            var evento = await _eventoService.GetById(id);
            if (evento?.EmailsConvidados != null && evento.EmailsConvidados.Count > 0)
            {
                var subject = $"Atualização da senha do evento: {evento.NomeEvento}";
                var body = $"A senha do evento '{evento.NomeEvento}' foi alterada. A nova senha é: {novaSenha}";

                foreach (var email in evento.EmailsConvidados)
                {
                    await _emailService.SendEmailAsync(new MensagemEmail
                    {
                        Destinatario = email,
                        Assunto = subject,
                        Conteudo = body
                    });
                }
            }

            return NoContent(); 
        }

    }
}
