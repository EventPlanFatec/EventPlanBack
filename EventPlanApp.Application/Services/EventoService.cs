using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class EventoService : ServiceBase<EventoDto, Evento>, IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUsuarioFinalRepository _usuarioFinalRepository;

        public EventoService(IEventoRepository eventoRepository, IMapper mapper, IUsuarioFinalRepository usuarioFinalRepository)
            : base(eventoRepository, mapper)
        {
            _eventoRepository = eventoRepository;
            _usuarioFinalRepository = usuarioFinalRepository;
        }

        public async Task<bool> InscreverNaListaDeEspera(int eventoId, InscricaoListaEsperaDTO inscricao)
        {
            var evento = await _eventoRepository.GetById(eventoId);
            if (evento == null)
            {
                return false;
            }

            if (evento.Ingressos.Count >= evento.LotacaoMaxima)
            {
                var usuarioExistente = await _usuarioFinalRepository.GetById(inscricao.UsuarioFinalId);

                if (usuarioExistente != null && !evento.UsuariosFinais.Any(u => u.Id == usuarioExistente.Id))
                {
                    evento.UsuariosFinais.Add(usuarioExistente);
                    await _eventoRepository.Update(eventoId, evento);
                    return true;
                }

                return false;
            }

            return false;
        }


    }
}
