using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventPlanApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly IUsuarioFinalRepository _usuarioFinalRepository;
        private readonly IEventoRepository _eventoRepository;
        private readonly EventPlanContext _context;

        public RecommendationsController(IUsuarioFinalRepository usuarioFinalRepository, IEventoRepository eventoRepository, EventPlanContext context)
        {
            _usuarioFinalRepository = usuarioFinalRepository;
            _eventoRepository = eventoRepository;
            _context = context;
        }

        // Endpoint GET /api/recommendations
        [HttpGet]
        public IActionResult GetRecommendations(Guid usuarioId) // Alterando o tipo para Guid
        {
            // Obtenha o usuário (por exemplo, de uma tabela de usuários ou de um contexto de autenticação)
            var usuario = _context.UsuariosFinais.FirstOrDefault(u => u.Id == usuarioId); // Removido Include, pois Preferencias é uma string

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // Recupera eventos baseados nas preferências do usuário
            // Alterando a lógica de comparação para garantir que Preferencias seja tratado como uma string
            var eventos = _context.Eventos
                .Where(e => e.Tags.Any(t => usuario.Preferencias.Contains(t.Nome))) // Comparando string com TagName
                .ToList();

            if (eventos == null || eventos.Count == 0)
            {
                return NotFound("Não há eventos disponíveis para as suas preferências.");
            }

            // Aqui estamos assumindo que você quer acessar o Valor de algum ingresso associado a cada evento
            var eventosRecomendados = eventos.Select(e => new
            {
                e.EventoId,
                e.NomeEvento,
                e.Descricao,
                e.DataInicio,
                e.DataFim,
                e.HorarioInicio,
                e.HorarioFim,
                e.LotacaoMaxima,
                e.NotaMedia,
                e.Genero,
                ValorIngresso = e.Ingressos.FirstOrDefault()?.Valor // Acessando o Valor do ingresso associado ao evento
            }).ToList();

            return Ok(eventosRecomendados);
        }
    }
}
