using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(EventPlanContext context) : base(context)
        {
        }
    }
}
