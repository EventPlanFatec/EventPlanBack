using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class UsuarioFinalRepository : BaseRepository<UsuarioFinal>, IUsuarioFinalRepository
    {
        public UsuarioFinalRepository(EventPlanContext context) : base(context)
        {
        }
        public async Task<UsuarioFinal> GetByEmailAsync(string email)
        {
            return await _context.Set<UsuarioFinal>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<UsuarioFinal>> GetByNameAsync(string nome)
        {
            return await _context.Set<UsuarioFinal>().Where(u => u.Nome.Contains(nome)).ToListAsync();
        }
    }
}
