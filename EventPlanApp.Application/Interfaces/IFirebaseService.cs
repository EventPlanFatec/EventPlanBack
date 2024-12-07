using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IFirebaseService
    {
        Task<List<Dictionary<string, object>>> GetEventosAsync();
        Task<Dictionary<string, object>> GetEventoByIdAsync(string id);
        Task UpdateEventoAsync(string id, Dictionary<string, object> eventoData);
        Task DeleteEventoAsync(string id);
    }
}
