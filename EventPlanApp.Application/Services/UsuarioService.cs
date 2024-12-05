using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Application.Services
{
    public class UsuarioService : ServiceBase<UsuarioDTO, Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
