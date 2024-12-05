using AutoMapper;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.API.Controllers
{
    public class EventoController : BaseController<EventoDTO, Evento>
    {
        public EventoController(IEventoService service, IMapper mapper)
            : base(service, mapper)
        {
        }

        protected override object GetIdFromDTO(EventoDTO dto)
        {
            return dto.Id;
        }
    }
}
