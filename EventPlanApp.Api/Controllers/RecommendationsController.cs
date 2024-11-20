using EventPlanApp.Application.Interfaces;
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
        private readonly IRecommendationService _recommendationService;

        public RecommendationsController(IUsuarioFinalRepository usuarioFinalRepository, IEventoRepository eventoRepository, EventPlanContext context, IRecommendationService recommendationService)
        {
            _usuarioFinalRepository = usuarioFinalRepository;
            _eventoRepository = eventoRepository;
            _context = context;
            _recommendationService = recommendationService;
        }

        // Endpoint GET /api/recommendations
        [HttpGet]
        public IActionResult GetRecommendations(Guid usuarioId)
        {
            var usuario = _context.UsuariosFinais.FirstOrDefault(u => u.Id == usuarioId);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // 1. Filtragem baseada em conteúdo: Buscar eventos com tags ou categorias que correspondem às preferências do usuário
            var eventosBaseadosEmPreferencias = _context.Eventos
                .Where(e => e.Tags.Any(t => usuario.Preferencias.Contains(t.Nome)) ||
                            e.Categorias.Any(c => usuario.Preferencias.Contains(c.Nome)))
                .ToList();

            // Se não houver eventos baseados nas preferências do usuário, podemos fazer uma filtragem colaborativa
            if (eventosBaseadosEmPreferencias.Count == 0)
            {
                // 2. Filtragem colaborativa: Buscar eventos recomendados com base em usuários semelhantes
                var usuariosSimilares = _context.UsuariosFinais
                    .Where(u => u.Preferencias.Intersect(usuario.Preferencias).Any()) // Comparar preferências parcialmente
                    .ToList();

                var eventosSimilares = usuariosSimilares
                    .SelectMany(u => u.Eventos)
                    .Distinct()
                    .ToList();

                eventosBaseadosEmPreferencias = eventosSimilares;
            }

            if (eventosBaseadosEmPreferencias.Count == 0)
            {
                return NotFound("Não há eventos disponíveis para as suas preferências.");
            }

            // Transformar eventos recomendados para o formato esperado pelo frontend
            var eventosRecomendados = eventosBaseadosEmPreferencias.Select(e => new
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
