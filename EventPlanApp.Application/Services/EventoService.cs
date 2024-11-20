using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class EventoService : ServiceBase<EventoDto, Evento>, IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUsuarioFinalRepository _usuarioFinalRepository;
        private readonly IEmailService _emailService;

        public EventoService(IEventoRepository eventoRepository,
                             IMapper mapper,
                             IUsuarioFinalRepository usuarioFinalRepository,
                             IEmailService emailService)
            : base(eventoRepository, mapper)
        {
            _eventoRepository = eventoRepository;
            _usuarioFinalRepository = usuarioFinalRepository;
            _emailService = emailService;
        }

        public async Task<bool> InscreverNaListaDeEspera(int eventoId, InscricaoListaEsperaDTO inscricao)
        {
            var evento = await _eventoRepository.GetById(eventoId);
            if (evento == null || evento.Ingressos.Count < evento.LotacaoMaxima)
                return false;

            var usuarioExistente = await _usuarioFinalRepository.GetById(inscricao.UsuarioFinalId);
            if (usuarioExistente != null && !evento.UsuariosFinais.Any(u => u.Id == usuarioExistente.Id))
            {
                evento.UsuariosFinais.Add(usuarioExistente);
                await _eventoRepository.Update(eventoId, evento);
                return true;
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
            if (evento == null) return false;

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
                evento.PasswordHash = HashPassword(senha);
            }
            await _eventoRepository.Add(evento);
        }

        public async Task<bool> ValidarSenha(int eventoId, string senha)
        {
            var evento = await _eventoRepository.GetById(eventoId);
            if (evento == null || !evento.IsPrivate) return false;

            return BCrypt.Net.BCrypt.Verify(senha, evento.PasswordHash);
        }

        public string HashPassword(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public async Task CriarEventoComConvidados(EventoDto eventoDto, string senha)
        {
            var evento = _mapper.Map<Evento>(eventoDto);

            if (eventoDto.EmailsConvidados != null && eventoDto.EmailsConvidados.Any())
            {
                foreach (var email in eventoDto.EmailsConvidados)
                {
                    var mensagem = new MensagemEmail
                    {
                        Destinatario = email,
                        Assunto = $"Convite para o evento {evento.NomeEvento}",
                        Conteudo = $"Você foi convidado para o evento {evento.NomeEvento}. " +
                                   $"A senha do evento é: {senha}."
                    };
                    await _emailService.SendEmailAsync(mensagem);
                }
            }

            if (evento.IsPrivate && !string.IsNullOrEmpty(senha))
            {
                evento.PasswordHash = HashPassword(senha);
            }

            await _eventoRepository.Add(evento);
        }

        public async Task<bool> UpdateEventPassword(int eventoId, string novaSenha)
        {
            var evento = await _eventoRepository.GetById(eventoId);
            if (evento == null)
            {
                return false;
            }

            evento.PasswordHash = HashPassword(novaSenha);
            await _eventoRepository.Update(eventoId, evento);

            return true;
        }
    }
}
