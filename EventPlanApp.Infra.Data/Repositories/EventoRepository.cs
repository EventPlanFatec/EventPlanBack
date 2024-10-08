﻿using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class EventoRepository : BaseRepository<Evento>, IEventoRepository
    {
        public EventoRepository(EventPlanContext context) : base(context)
        {
        }

        public async Task<Evento> AdicionarEventoComSenhaAsync(Evento evento, string senha)
        {
            if (evento.IsPrivate && !string.IsNullOrEmpty(senha))
            {
                evento.PasswordHash = BCrypt.Net.BCrypt.HashPassword(senha);
            }

            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<bool> ValidarSenhaEventoAsync(int eventoId, string senha)
        {
            var evento = await _context.Eventos.FindAsync(eventoId);
            if (evento == null || !evento.IsPrivate)
            {
                return false; 
            }

            return BCrypt.Net.BCrypt.Verify(senha, evento.PasswordHash);
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
