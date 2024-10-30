using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class IngressoRepository : IIngressoRepository
    {
        private readonly EventPlanContext _context;

        public IngressoRepository(EventPlanContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ingresso ingresso)
        {
            await _context.Ingressos.AddAsync(ingresso);
            await _context.SaveChangesAsync();
        }

        public async Task<Ingresso> GetByIdAsync(int ingressoId)
        {
            return await _context.Ingressos.FindAsync(ingressoId);
        }

        public async Task<IEnumerable<Ingresso>> GetAllAsync()
        {
            return await _context.Ingressos.ToListAsync();
        }

        public async Task UpdateAsync(Ingresso ingresso)
        {
            _context.Ingressos.Update(ingresso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int ingressoId)
        {
            var ingresso = await GetByIdAsync(ingressoId);
            if (ingresso != null)
            {
                _context.Ingressos.Remove(ingresso);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Ingresso>> GetByEventoIdAsync(int eventoId)
        {
            return await _context.Ingressos
                .Where(i => i.EventoId == eventoId)
                .ToListAsync();
        }
    }
}
