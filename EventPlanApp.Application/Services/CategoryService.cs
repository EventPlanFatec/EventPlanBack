using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Application.Services
{
    public class CategoryService : ServiceBase<CategoryDTO, Categoria>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
            : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
