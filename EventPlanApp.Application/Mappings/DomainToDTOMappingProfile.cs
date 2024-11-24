using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.Imagens, opt => opt.MapFrom(src => new List<string> { src.Imagens }))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(tag => tag.Nome).ToList())); 

            CreateMap<EventoDto, Evento>()
                .ForMember(dest => dest.Imagens, opt => opt.MapFrom(src => src.Imagens != null && src.Imagens.Any() ? string.Join(",", src.Imagens) : string.Empty))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(tagName => new Tag { Nome = tagName }).ToList())); 

            CreateMap<Endereco, EnderecoDto>().ReverseMap();
            CreateMap<Ingresso, IngressoDto>().ReverseMap();
            CreateMap<Organizacao, OrganizacaoDto>().ReverseMap();
            CreateMap<UsuarioAdm, UsuarioAdmDto>().ReverseMap();
            CreateMap<UsuarioFinal, UsuarioFinalDto>().ReverseMap();
        }
    }
}
