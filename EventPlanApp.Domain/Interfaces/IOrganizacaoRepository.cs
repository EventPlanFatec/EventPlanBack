using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IOrganizacaoRepository : IRepository<Organizacao>
    {
        Task<IEnumerable<Organizacao>> FindAsync(Expression<Func<Organizacao, bool>> predicate);
        Task AddAsync(Organizacao organizacao);
        Task<Organizacao> GetByIdAsync(int id);
        Task<IEnumerable<Organizacao>> GetAllAsync();
        Task UpdateAsync(Organizacao entity);
        Task DeleteAsync(int id);

    }
}
