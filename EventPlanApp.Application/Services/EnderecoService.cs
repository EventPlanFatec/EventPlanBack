using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Application.Services
{
    public class EnderecoService : ServiceBase<EnderecoDTO, Endereco>, IEnderecoService
    {
        public EnderecoService(IEnderecoRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
