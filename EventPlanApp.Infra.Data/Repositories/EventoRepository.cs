using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class EventoRepository : BaseRepository<Evento>, IEventoRepository
    {
        public EventoRepository(EventPlanContext context) : base(context)
        {
        }
    }
}
