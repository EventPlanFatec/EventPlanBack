using AutoMapper;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.API.Controllers
{
    public class CategoriaController : BaseController<CategoriaDTO, Categoria>
    {
        public CategoriaController(ICategoriaService service, IMapper mapper)
            : base(service, mapper)
        {
        }

        protected override object GetIdFromDTO(CategoriaDTO dto)
        {
            return dto.Id;
        }
    }
}
