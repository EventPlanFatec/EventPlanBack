using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Categoria>, ICategoryRepository
    {
        private readonly EventPlanContext _context;

        public CategoryRepository(EventPlanContext context) : base(context)
        {
            _context = context;
        }
    }
}
