using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class IngressoRepository : BaseRepository<Ingresso>, IIngressoRepository
    {
        public IngressoRepository(EventPlanContext context) : base(context)
        {
        }
    }
}
