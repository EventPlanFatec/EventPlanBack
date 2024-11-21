using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using Microsoft.EntityFrameworkCore;
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
        private readonly EventPlanContext _context;

        public EventoService(IEventoRepository eventoRepository,
                             IMapper mapper,
                             IUsuarioFinalRepository usuarioFinalRepository,
                             IEmailService emailService, EventPlanContext context)
            : base(eventoRepository, mapper)
        {
            _eventoRepository = eventoRepository;
            _usuarioFinalRepository = usuarioFinalRepository;
            _emailService = emailService;
            _context = context;
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

        public async Task<IEnumerable<Evento>> ObterEventosPorCategoriaAsync(int categoriaId)
        {
            var eventos = await _eventoRepository.BuscarEventosPorCategoriaAsync(categoriaId);

            if (!eventos.Any())
                throw new KeyNotFoundException("Nenhum evento encontrado para a categoria especificada.");

            return eventos;
        }

        public async Task<IEnumerable<Evento>> BuscarEventosPorCategoriaAsync(int categoriaId)
        {
            return await _eventoRepository.BuscarEventosPorCategoriaAsync(categoriaId);
        }

        // Implementação da busca por nome
        public async Task<IEnumerable<Evento>> BuscarEventosPorNomeAsync(string nome)
        {
            // Chama o repositório para buscar os eventos que contêm o nome fornecido
            return await _eventoRepository.BuscarEventosPorNomeAsync(nome);
        }

        // Implementação da busca por localização
        public async Task<IEnumerable<Evento>> BuscarEventosPorLocalizacaoAsync(string cidade, string estado)
        {
            // Chama o repositório para buscar eventos com base na cidade ou estado
            return await _eventoRepository.BuscarEventosPorLocalizacaoAsync(cidade, estado);
        }

        // Método para buscar eventos com múltiplos filtros
        public async Task<IEnumerable<Evento>> BuscarEventosComFiltrosAsync(
            string nome, string categoria, string cidade, string estado)
        {
            return await _eventoRepository.BuscarEventosComFiltrosAsync(nome, categoria, cidade, estado);
        }

        public async Task<int> ObterNumeroDeInscritosAsync(int eventoId, int organizacaoId)
        {
            // Verifica se o evento existe e se o organizador (organização) tem acesso ao evento
            var evento = await _context.Eventos
                .FirstOrDefaultAsync(e => e.EventoId == eventoId && e.OrganizacaoId == organizacaoId);

            // Caso o evento não seja encontrado ou o organizador não tenha permissão
            if (evento == null)
            {
                throw new UnauthorizedAccessException("Você não tem permissão para acessar este evento.");
            }

            // Chama o repositório para obter o número de inscritos
            return await _eventoRepository.ObterNumeroDeInscritosAsync(eventoId);
        }

        public async Task<IEnumerable<HistoricoDeEventoDto>> ObterHistoricoDeEventosComEngajamentoAsync(int organizadorId)
        {
            // Buscar os eventos passados relacionados ao organizador
            var eventos = await _context.Eventos
                .Where(e => e.OrganizacaoId == organizadorId && e.DataFim < DateTime.Now) // Só eventos passados
                .ToListAsync();

            var eventosComEngajamento = new List<HistoricoDeEventoDto>(); // Usando o tipo esperado

            foreach (var evento in eventos)
            {
                // Obter o número total de inscritos
                var totalInscritos = await _context.Inscricoes
                    .Where(i => i.EventoId == evento.EventoId)
                    .CountAsync();

                // Obter o número de presenças
                var presencas = await _context.Inscricoes
                    .Where(i => i.EventoId == evento.EventoId && i.Status == "Presente")
                    .CountAsync();

                // Calcular taxa de presença
                decimal taxaDePresenca = totalInscritos == 0 ? 0 : (decimal)presencas / totalInscritos * 100;

                // Obter as avaliações médias
                var avaliacaoMedia = await _context.Avaliacoes
                    .Where(a => a.EventoId == evento.EventoId)
                    .AverageAsync(a => (double?)a.Avaliacao); // Garantir que o tipo seja nullable

                // Se não houver avaliações, defina 0 como valor padrão
                avaliacaoMedia = avaliacaoMedia ?? 0;

                // Adicionar as estatísticas ao DTO
                var eventoComEngajamento = new HistoricoDeEventoDto
                {
                    EventoId = evento.EventoId,
                    NomeEvento = evento.NomeEvento,
                    DataInicio = evento.DataInicio,
                    DataFim = evento.DataFim,
                    TotalInscritos = totalInscritos,
                    TaxaDePresenca = taxaDePresenca,
                    AvaliacaoMedia = (decimal)avaliacaoMedia // Garantir que seja decimal
                };

                eventosComEngajamento.Add(eventoComEngajamento);
            }

            return eventosComEngajamento.AsEnumerable(); // Retornar como IEnumerable
        }


        public async Task<decimal> CalcularTaxaDeCancelamentoAsync(int eventoId, int organizadorId)
        {
            // Buscar o evento com o organizadorId correto
            var evento = await _context.Eventos
                .FirstOrDefaultAsync(e => e.EventoId == eventoId && e.OrganizacaoId == organizadorId);

            if (evento == null)
            {
                throw new UnauthorizedAccessException("Você não tem permissão para acessar este evento.");
            }

            // Obter o número total de inscrições
            var totalInscritos = await _context.Inscricoes
                .Where(i => i.EventoId == eventoId)
                .CountAsync();

            // Obter o número de inscrições canceladas
            var totalCanceladas = await _context.Inscricoes
                .Where(i => i.EventoId == eventoId && i.Status == "Cancelada")
                .CountAsync();

            // Calcular a taxa de cancelamento
            decimal taxaDeCancelamento = totalInscritos == 0 ? 0 : (decimal)totalCanceladas / totalInscritos * 100;

            return taxaDeCancelamento;
        }

        
    }

}
