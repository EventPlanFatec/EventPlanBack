using EventPlanApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class OrganizacaoRepository : BaseRepository<Organizacao>, IOrganizacaoRepository
    {
        public OrganizacaoRepository(EventPlanContext context) : base(context)
        {
         
        }
        public async Task<IEnumerable<Organizacao>> FindAsync(Expression<Func<Organizacao, bool>> predicate)
        {
            return await _context.Organizacoes
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddAsync(Organizacao organizacao)
        {
            await _context.Organizacoes.AddAsync(organizacao);
            await _context.SaveChangesAsync();
        }

        public async Task<Organizacao> GetByIdAsync(int id)
        {
            return await _context.Organizacoes.FindAsync(id);
        }

        public async Task<IEnumerable<Organizacao>> GetAllAsync()
        {
            return await _context.Organizacoes.ToListAsync();
        }

        public async Task UpdateAsync(Organizacao entity)
        {
            _context.Organizacoes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Organizacoes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
