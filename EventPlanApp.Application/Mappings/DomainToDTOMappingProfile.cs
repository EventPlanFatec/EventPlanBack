using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Evento, EventoDTO>().ReverseMap();
        }
    }
}
