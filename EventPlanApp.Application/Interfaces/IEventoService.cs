using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Application.Interfaces
{
    public interface IEventoService : IService<EventoDTO>
    {
        // Métodos específicos de Evento, se necessário
    }
}
