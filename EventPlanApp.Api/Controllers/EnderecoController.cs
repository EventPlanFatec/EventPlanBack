using AutoMapper;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.API.Controllers
{
    public class EnderecoController : BaseController<EnderecoDTO, Endereco>
    {
        public EnderecoController(IEnderecoService service, IMapper mapper)
            : base(service, mapper)
        {
        }

        protected override object GetIdFromDTO(EnderecoDTO dto)
        {
            return dto.Id;
        }
    }
}
