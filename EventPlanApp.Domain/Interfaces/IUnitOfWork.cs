using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventoRepository EventoRepository { get; }
        ITaxaServicoConfigRepository TaxaServicoConfigRepository { get; }
        Task<int> CommitAsync();
    }
}
