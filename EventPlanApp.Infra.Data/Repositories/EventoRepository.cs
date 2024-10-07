using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class EventoRepository : BaseRepository<Evento>, IEventoRepository
    {
        public EventoRepository(EventPlanContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Evento>> ObterEventosLotadosAsync()
        {
            return await _context.Eventos
                                 .Where(e => e.Ingressos.Count() >= e.LotacaoMaxima)
                                 .ToListAsync();
        }


        public async Task<IEnumerable<UsuarioFinal>> ObterUsuariosListaEsperaAsync(int eventoId)
        {
            return await _context.UsuariosFinais
                                 .Where(u => u.ListasEspera.Any(l => l.EventoId == eventoId))
                                 .ToListAsync();
        }
        public async Task RemoverListaEsperaAsync(ListaEspera listaEspera)
        {
            _context.ListasEspera.Remove(listaEspera);
            await _context.SaveChangesAsync();
        }
    }
}
