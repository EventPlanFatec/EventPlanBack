using EventPlanApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IEventoRepository : IRepository<Evento>
    {
        Task<Evento> AdicionarEventoComSenhaAsync(Evento evento, string senha);
        Task<bool> ValidarSenhaEventoAsync(int eventoId, string senha);
        Task<IEnumerable<Evento>> ObterEventosLotadosAsync();
        Task<IEnumerable<UsuarioFinal>> ObterUsuariosListaEsperaAsync(int eventoId);
        Task RemoverListaEsperaAsync(ListaEspera listaEspera);
        Task<Evento> GetByIdAsync(int eventoId);
        Task UpdateAsync(Evento evento);
        Task<IEnumerable<Evento>> GetAllAsync();
    }
}
