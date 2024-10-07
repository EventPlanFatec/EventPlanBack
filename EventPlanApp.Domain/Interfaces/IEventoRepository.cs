using EventPlanApp.Domain.Entities;
using System.Collections.Generic;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IEventoRepository : IRepository<Evento>
    {
        Task<IEnumerable<Evento>> ObterEventosLotadosAsync();
        Task<IEnumerable<UsuarioFinal>> ObterUsuariosListaEsperaAsync(int eventoId);
    }

}
