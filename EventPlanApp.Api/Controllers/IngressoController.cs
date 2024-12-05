using AutoMapper;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.API.Controllers
{
    public class IngressoController : BaseController<IngressoDTO, Ingresso>
    {
        public IngressoController(IIngressoService service, IMapper mapper)
            : base(service, mapper)
        {
        }

        protected override object GetIdFromDTO(IngressoDTO dto)
        {
            return dto.Id;
        }
    }
}
