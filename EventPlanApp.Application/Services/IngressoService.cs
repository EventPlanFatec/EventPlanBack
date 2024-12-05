using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Application.Services
{
    public class IngressoService : ServiceBase<IngressoDTO, Ingresso>, IIngressoService
    {
        public IngressoService(IIngressoRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
