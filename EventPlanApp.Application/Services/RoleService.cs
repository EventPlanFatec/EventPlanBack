using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Application.Services
{
    public class RoleService : ServiceBase<RoleDTO, Role>, IRoleService
    {
        public RoleService(IRoleRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
