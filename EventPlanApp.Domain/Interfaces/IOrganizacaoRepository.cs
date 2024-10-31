using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IOrganizacaoRepository : IRepository<Organizacao>
    {
        Task AddAsync(Organizacao organizacao);
        
    }
}
