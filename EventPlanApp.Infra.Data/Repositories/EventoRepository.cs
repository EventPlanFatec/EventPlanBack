using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class EventoRepository : BaseRepository<Evento>, IEventoRepository
    {
        public EventoRepository(EventPlanContext context) : base(context)
        {
        }

        public async Task<bool> ExistsById(string id)
        {
            return await _context.Set<Evento>().AnyAsync(e => e.Id == id);
        }
    }
}
