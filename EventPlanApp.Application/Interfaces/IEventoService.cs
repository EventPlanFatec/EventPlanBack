using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Application.Interfaces
{
    public interface IEventoService : IService<EventoDto>
    {
        Task<bool> InscreverNaListaDeEspera(int eventoId, InscricaoListaEsperaDTO inscricao);
        Task<bool> RemoverInscricaoAsync(int eventoId, int usuarioFinalId);
        Task<bool> ValidarSenha(int eventoId, string senha);
        string HashPassword(string senha);
        Task<bool> UpdateEventPassword(int eventoId, string novaSenha);
        Task<IEnumerable<Evento>> ObterEventosPorCategoriaAsync(int categoriaId);
    }

}
