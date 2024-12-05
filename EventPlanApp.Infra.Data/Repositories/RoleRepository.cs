using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(EventPlanContext context) : base(context)
        {
        }
    }
}
