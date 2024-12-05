using AutoMapper;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.API.Controllers
{
    public class UsuarioController : BaseController<UsuarioDTO, Usuario>
    {
        public UsuarioController(IUsuarioService service, IMapper mapper)
            : base(service, mapper)
        {
        }

        protected override object GetIdFromDTO(UsuarioDTO dto)
        {
            return dto.Id;
        }
    }
}
