using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Application.Services
{
    public class EventoService : ServiceBase<EventoDTO, Evento>, IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository, IMapper mapper)
            : base(eventoRepository, mapper)
        {
            _eventoRepository = eventoRepository;
        }
    }
}
