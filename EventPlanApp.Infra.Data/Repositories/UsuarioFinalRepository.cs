using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<UsuarioFinal>> FindAsync(Expression<Func<UsuarioFinal, bool>> predicate)
        {
            return await _context.Set<UsuarioFinal>().Where(predicate).ToListAsync();
        }

       
        public async Task UpdateAsync(UsuarioFinal usuarioFinal)
        {
            _context.UsuariosFinais.Update(usuarioFinal);
            await _context.SaveChangesAsync();
        }
        public async Task<UsuarioFinal> GetByIdAsync(Guid id)
        {
            return await _context.UsuariosFinais
                                 .FirstOrDefaultAsync(u => u.Id == id); // Correto agora
        }
    }
}
