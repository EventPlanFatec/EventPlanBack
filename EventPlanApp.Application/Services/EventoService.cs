using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Application.Services
{
    public class EventoService : ServiceBase<EventoDTO, Evento>, IEventoService
    {
        public EventoService(IEventoRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
