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
        public async Task<List<UsuarioFinal>> ObterUsuariosDaListaEspera(int eventoId)
        {
            var usuariosNaListaEspera = await _eventoRepository.ObterUsuariosListaEsperaAsync(eventoId);
            return usuariosNaListaEspera.ToList();
        }

        public async Task<bool> RemoverInscricaoAsync(int eventoId, int usuarioFinalId)
        {
            var evento = await _eventoRepository.GetById(eventoId);
            if (evento == null)
            {
                return false;
            }

            var usuarioExistente = await _usuarioFinalRepository.GetById(usuarioFinalId);
            if (usuarioExistente != null && evento.UsuariosFinais.Any(u => u.Id == usuarioExistente.Id))
            {
                evento.UsuariosFinais.Remove(usuarioExistente);
                await _eventoRepository.Update(eventoId, evento);
                return true;
            }

            return false;
        }
        public async Task CriarEvento(Evento evento, string senha)
        {
            if (evento.IsPrivate && !string.IsNullOrEmpty(senha))
            {
                evento.PasswordHash = BCrypt.Net.BCrypt.HashPassword(senha);
            }

            await _eventoRepository.Add(evento);
        }

        public async Task<bool> ValidarSenha(int eventoId, string senha)
        {
            var evento = await _eventoRepository.GetById(eventoId);
            if (evento == null || !evento.IsPrivate)
            {
                return false; 
            }

            return BCrypt.Net.BCrypt.Verify(senha, evento.PasswordHash);
        }

        public string HashPassword(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);

        public async Task<bool> RemoverInscricaoAsync(int eventoId, int usuarioFinalId)
        {
            var evento = await _eventoRepository.GetById(eventoId);
            if (evento == null)
            {
                return false;
            }

            var usuarioExistente = await _usuarioFinalRepository.GetById(usuarioFinalId);
            if (usuarioExistente != null && evento.UsuariosFinais.Any(u => u.Id == usuarioExistente.Id))
            {
                evento.UsuariosFinais.Remove(usuarioExistente);
                await _eventoRepository.Update(eventoId, evento);
                return true;
            }

            return false;
        }
    }
}
