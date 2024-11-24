using System.Threading.Tasks;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Application.Interfaces
{
    public interface ITaxaServicoConfigService
    {
        Task AdicionarOuAtualizarTaxaAsync(int eventoId, decimal? taxaFixa, decimal? taxaPercentual);
    }
}
