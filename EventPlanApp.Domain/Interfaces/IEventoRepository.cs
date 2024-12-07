using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IEventoRepository : IRepository<Evento>
    {
        Task<bool> ExistsById(string id);
    }
}
