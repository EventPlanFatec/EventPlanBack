using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class UsuarioFinalRepository : BaseRepository<UsuarioFinal>, IUsuarioFinalRepository
    {
        public UsuarioFinalRepository(EventPlanContext context) : base(context)
        {
        }
    }
}
