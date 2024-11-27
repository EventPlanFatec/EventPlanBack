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
        Task<IEnumerable<Evento>> BuscarEventosPorNomeAsync(string nome);
        Task<IEnumerable<Evento>> BuscarEventosPorLocalizacaoAsync(string cidade, string estado);
        Task<IEnumerable<Evento>> BuscarEventosComFiltrosAsync(
       string nome, string categoria, string cidade, string estado);

        Task<int> ObterNumeroDeInscritosAsync(int eventoId, int organizadorId);
        Task<decimal> CalcularTaxaDeCancelamentoAsync(int eventoId, int organizadorId);
        Task<IEnumerable<HistoricoDeEventoDto>> ObterHistoricoDeEventosComEngajamentoAsync(int organizadorId);
        Task<Evento> ObterEventoPorIdAsync(int id);
        Task<List<Evento>> ObterTodosEventosAsync();

    }

}
