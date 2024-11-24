using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface ITaxaServicoConfigRepository
    {
        Task<IEnumerable<TaxaServicoConfig>> GetAllAsync();
        Task<TaxaServicoConfig> GetByIdAsync(int id);
        Task<IEnumerable<TaxaServicoConfig>> GetByEventoIdAsync(int eventoId);
        Task AddAsync(TaxaServicoConfig taxaServicoConfig);
        void Update(TaxaServicoConfig taxaServicoConfig);
        void Remove(TaxaServicoConfig taxaServicoConfig);
        Task<TaxaServicoConfig> ObterTaxaServicoPorEventoAsync(int eventoId);

    }
}
