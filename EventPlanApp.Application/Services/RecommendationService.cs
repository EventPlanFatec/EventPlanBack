using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly EventPlanContext _context;

        public RecommendationService(EventPlanContext context)
        {
            _context = context;
        }

        // Filtragem baseada em conteúdo
        public async Task<List<Evento>> GetRecommendedEventsAsync(Guid usuarioId)
        {
            var usuario = await _context.UsuariosFinais
                .Include(u => u.Preferencias)
                .Include(u => u.Eventos)
                .FirstOrDefaultAsync(u => u.Id == usuarioId);

            if (usuario == null)
            {
                return new List<Evento>(); // Nenhum usuário encontrado
            }

            // Filtragem baseada em conteúdo: seleciona eventos com tags que o usuário tem interesse
            var eventosRecomendados = _context.Eventos
                .Where(e => e.Tags.Any(t => usuario.Preferencias.Contains(t.Nome))) // Assume que `Preferencias` contém tags de interesse
                .ToList();

            // Filtragem colaborativa: encontra usuários semelhantes e recomenda eventos baseados nas interações anteriores
            var usuariosSimilares = _context.UsuariosFinais
                .Where(u => u.Preferencias == usuario.Preferencias) // Você pode refinar essa lógica
                .ToList();

            foreach (var usuarioSimilar in usuariosSimilares)
            {
                eventosRecomendados.AddRange(usuarioSimilar.Eventos); // Adiciona eventos dos usuários semelhantes
            }

            // Remover duplicatas
            eventosRecomendados = eventosRecomendados.Distinct().ToList();

            return eventosRecomendados;
        }
    }
}
