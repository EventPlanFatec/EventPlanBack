using AutoMapper;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.API.Controllers
{
    public class RoleController : BaseController<RoleDTO, Role>
    {
        public RoleController(IRoleService service, IMapper mapper)
            : base(service, mapper)
        {
        }

        protected override object GetIdFromDTO(RoleDTO dto)
        {
            return dto.Id;
        }
    }
}
    