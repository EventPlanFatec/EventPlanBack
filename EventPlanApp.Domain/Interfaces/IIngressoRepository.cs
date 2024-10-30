using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IIngressoRepository
    {
        Task AddAsync(Ingresso ingresso);
        Task<Ingresso> GetByIdAsync(int ingressoId);
        Task<IEnumerable<Ingresso>> GetAllAsync();
        Task UpdateAsync(Ingresso ingresso);
        Task DeleteAsync(int ingressoId);

        
    }
}
