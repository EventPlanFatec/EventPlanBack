using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Application.Services
{
    public class CategoriaService : ServiceBase<CategoriaDTO, Categoria>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
