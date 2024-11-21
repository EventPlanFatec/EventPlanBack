using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.Services;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using EventPlanApp.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IEventoRepository _eventoRepository;
        private readonly IIngressoRepository _ingressoRepository;
        private readonly ILogger<EventoController> _logger;
        private readonly EventPlanContext _context;
        private readonly Application.Interfaces.IAuthorizationService _authorizationService;
        private readonly IPermissionService _permissionService;


        public EventoController(IEventoService eventoService, IMapper mapper, IEmailService emailService, IIngressoRepository ingressoRepository, ILogger<EventoController> logger, EventPlanContext context, Application.Interfaces.IAuthorizationService authorizationService, IPermissionService permissionService)
        {
            _eventoService = eventoService;
            _mapper = mapper;
            _emailService = emailService;
            _ingressoRepository = ingressoRepository;
            _logger = logger;
            _context = context;
            _authorizationService = authorizationService;
            _permissionService = permissionService;
        }

        [HttpGet("{id}/compartilhar/facebook")]
        public IActionResult CompartilharNoFacebook(int id)
        {
            var eventoUrl = GerarLinkDoEvento(id);
            var facebookShareUrl = $"https://www.facebook.com/sharer/sharer.php?u={Uri.EscapeDataString(eventoUrl)}";
            return Redirect(facebookShareUrl);
        }

        [HttpGet("{id}/compartilhar/whatsapp")]
        public IActionResult CompartilharNoWhatsapp(int id)
        {
            var eventoUrl = GerarLinkDoEvento(id);
            var whatsappShareUrl = $"https://wa.me/?text={Uri.EscapeDataString(eventoUrl)}";
            return Redirect(whatsappShareUrl);
        }

        private string GerarLinkDoEvento(int id)
        {
            return $"http://{id}/evento";
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

        [HttpDelete("{id1}")]
        public async Task<IActionResult> CancelarEvento(int id)
        {
            var evento = await _eventoRepository.GetByIdAsync(id);
            if (evento == null)
            {
                return NotFound("Evento não encontrado.");
            }

            evento.Cancelar();
            await _eventoRepository.UpdateAsync(evento);

            var ingressos = await _ingressoRepository.GetByEventoIdAsync(id);
            foreach (var ingresso in ingressos)
            {
                var mensagemEmail = new MensagemEmail
                {
                    Destinatario = ingresso.UsuarioFinal.Email,
                    Assunto = $"Cancelamento do Evento: {evento.NomeEvento}",
                    Conteudo = $"O evento {evento.NomeEvento} foi cancelado. Detalhes sobre o reembolso: ... "
                };

                await _emailService.SendEmailAsync(mensagemEmail);
                _logger.LogInformation($"Notificação enviada para {ingresso.UsuarioFinal.Email} sobre o cancelamento do evento {evento.NomeEvento}.");
            }

            return Ok("Evento cancelado e notificações enviadas.");
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] Evento eventoAtualizado)
        {
            if (id != eventoAtualizado.EventoId)
            {
                return BadRequest("O ID do evento na URL não corresponde ao ID do evento no corpo da requisição.");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var eventoExistente = await _eventoRepository.GetByIdAsync(id);
                if (eventoExistente == null)
                {
                    return NotFound("Evento não encontrado.");
                }

                eventoExistente.AtualizarEvento(
                    eventoAtualizado.NomeEvento,
                    eventoAtualizado.DataInicio,
                    eventoAtualizado.DataFim,
                    eventoAtualizado.HorarioInicio,
                    eventoAtualizado.HorarioFim,
                    eventoAtualizado.LotacaoMaxima
                );

                await _eventoRepository.UpdateAsync(eventoExistente);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar o evento: {ex.Message}");
            }
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

        [HttpPut("{id}/categorias")]
        public async Task<IActionResult> UpdateEventCategories(int id, [FromBody] EventoDto eventoDto)
        {
            if (eventoDto == null || eventoDto.CategoriaIds == null || eventoDto.CategoriaIds.Count == 0)
            {
                return BadRequest("Evento ou categorias não fornecidos.");
            }

            var evento = await _context.Eventos
                .Include(e => e.EventoCategorias)
                .ThenInclude(ec => ec.Categoria)
                .FirstOrDefaultAsync(e => e.EventoId == id);

            if (evento == null)
            {
                return NotFound($"Evento com ID {id} não encontrado.");
            }

            evento.EventoCategorias.Clear();

            foreach (var categoriaId in eventoDto.CategoriaIds)
            {
                var categoria = await _context.Categorias.FindAsync(categoriaId);
                if (categoria != null)
                {
                    evento.EventoCategorias.Add(new EventoCategoria
                    {
                        EventoId = evento.EventoId,
                        CategoriaId = categoriaId
                    });
                }
            }

            await _context.SaveChangesAsync();
            return Ok("Categorias do evento atualizadas com sucesso.");
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<EventoDto>>> SearchEvents([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return BadRequest("A palavra-chave de pesquisa não pode ser vazia.");
            }

            var events = await _context.Eventos
                .Where(e => e.NomeEvento.Contains(q) ||
                            e.Descricao.Contains(q) ||
                            e.Tags.Any(t => t.Nome.Contains(q)))  // Verificando se o nome da tag contém a palavra-chave
                .Select(e => new EventoDto
                {
                    EventoId = e.EventoId,
                    NomeEvento = e.NomeEvento,
                    Descricao = e.Descricao,
                    Tags = e.Tags.Select(t => t.Nome).ToList(),  // Converte a lista de objetos Tag para uma lista de strings

                })
                .ToListAsync();

            if (events == null || !events.Any())
            {
                return NotFound("Nenhum evento encontrado com a palavra-chave fornecida.");
            }

            return Ok(events);
        }

        // GET: api/events
        [HttpGet("filter")]
        public async Task<IActionResult> GetEvents(
            [FromQuery] DateTime? dataInicio,
            [FromQuery] DateTime? dataFim,
            [FromQuery] string localizacao,
            [FromQuery] string tipoEvento)
        {
            var query = _context.Eventos.AsQueryable();

            // Filtro por data de início
            if (dataInicio.HasValue)
            {
                query = query.Where(e => e.DataInicio >= dataInicio.Value);
            }

            // Filtro por data de fim
            if (dataFim.HasValue)
            {
                query = query.Where(e => e.DataFim <= dataFim.Value);
            }

            // Filtro por localização (cidade, estado)
            if (!string.IsNullOrEmpty(localizacao))
            {
                query = query.Where(e => e.Endereco.Cidade.Contains(localizacao) || e.Endereco.Estado.Contains(localizacao));
            }

            // Filtro por tipo de evento (gênero)
            if (!string.IsNullOrEmpty(tipoEvento))
            {
                query = query.Where(e => e.Genero.Contains(tipoEvento));
            }

            // Carregar os eventos filtrados
            var eventos = await query.ToListAsync();

            return Ok(eventos);
        }
        [HttpPut("{id}/categories")]
        public async Task<IActionResult> UpdateEventCategories(int id, [FromBody] int[] categoryIds)
        {
            // Validar se o evento existe
            var evento = await _context.Eventos
                .Include(e => e.Categorias) // Incluir as categorias associadas ao evento
                .FirstOrDefaultAsync(e => e.EventoId == id);

            if (evento == null)
            {
                return NotFound(new { message = "Evento não encontrado." });
            }

            // Validar se as categorias existem
            var categorias = await _context.Categorias
                .Where(c => categoryIds.Contains(c.CategoriaId))
                .ToListAsync();

            if (categorias.Count != categoryIds.Length)
            {
                return BadRequest(new { message = "Algumas categorias não foram encontradas." });
            }

            // Atualizar as categorias associadas ao evento
            evento.Categorias.Clear(); // Remover categorias atuais
            evento.Categorias.AddRange(categorias); // Adicionar novas categorias

            // Salvar as mudanças no banco de dados
            await _context.SaveChangesAsync();

            return Ok(new { message = "Categorias atualizadas com sucesso!" });
        }

        [HttpPut("api/events/{id}/guests")]
        public async Task<IActionResult> AdicionarConvidados(int id, [FromBody] List<string> emails)
        {
            // Buscar o evento no banco de dados
            var evento = await _context.Eventos.Include(e => e.ListaConvidados).FirstOrDefaultAsync(e => e.EventoId == id);

            if (evento == null)
            {
                return NotFound("Evento não encontrado.");
            }

            try
            {
                // Chama o método para adicionar os convidados
                evento.AdicionarConvidados(emails);

                // Salvar as mudanças no banco de dados
                _context.Eventos.Update(evento);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Convidados adicionados com sucesso." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("api/events/{id}/privacy")]
        public async Task<IActionResult> UpdateEventoPrivacy(int id, [FromBody] UpdateEventoPrivacyRequest request)
        {
            // Validação de entrada
            if (request == null)
            {
                return BadRequest("A solicitação é inválida.");
            }

            // Lógica para buscar o evento pelo id
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound("Evento não encontrado.");
            }

            // Atualizar a configuração de privacidade
            evento.Privacidade = request.Privacidade;

            // Caso precise atualizar convidados (para evento privado)
            if (request.Convidados != null && evento.Privacidade)
            {
                evento.ListaConvidados = request.Convidados;  // Alterar para ListaConvidados
            }

            try
            {
                // Salvar as alterações no banco de dados
                await _context.SaveChangesAsync();
                return Ok("Configuração de privacidade atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar a privacidade do evento: {ex.Message}");
            }
        }

        [HttpGet("restricted-area")]
        public async Task<IActionResult> GetRestrictedArea()
        {
            // Verificar se o usuário tem acesso
            var userHasAccess = await _authorizationService.CheckUserPermissionAsync(User);

            if (!userHasAccess)
            {
                return Forbid("Você não tem permissão para acessar esta área.");
            }

            return Ok("Você tem acesso a essa área.");
        }

        [HttpGet("secure-endpoint")]
        public async Task<IActionResult> SecureEndpoint()
        {
            var user = HttpContext.User;

            // Verificar permissão
            var hasPermission = await _permissionService.CheckUserPermissionAsync(user, "RequiredPermission");

            if (!hasPermission)
            {
                // Retorna mensagem de acesso negado
                return Forbid("Você não possui permissão para acessar este recurso.");
            }

            // Se tiver permissão, retorna uma resposta de sucesso
            return Ok("Acesso permitido!");
        }
    }
}
