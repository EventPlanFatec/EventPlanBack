using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class EventoRepository : BaseRepository<Evento>, IEventoRepository
    {
        private readonly EventPlanContext _context;
        public EventoRepository(EventPlanContext context) : base(context)
        {
            _context = context;

        }


        public async Task<Evento> AdicionarEventoComSenhaAsync(Evento evento, string senha)
        {
            if (evento.IsPrivate && !string.IsNullOrEmpty(senha))
            {
                evento.PasswordHash = BCrypt.Net.BCrypt.HashPassword(senha);
            }

            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<bool> ValidarSenhaEventoAsync(int eventoId, string senha)
        {
            var evento = await _context.Eventos.FindAsync(eventoId);
            if (evento == null || !evento.IsPrivate)
            {
                return false; 
            }

            return BCrypt.Net.BCrypt.Verify(senha, evento.PasswordHash);
        }

        public async Task<IEnumerable<Evento>> ObterEventosLotadosAsync()
        {
            return await _context.Eventos
                                 .Where(e => e.Ingressos.Count() >= e.LotacaoMaxima)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioFinal>> ObterUsuariosListaEsperaAsync(int eventoId)
        {
            return await _context.UsuariosFinais
                                 .Where(u => u.ListasEspera.Any(l => l.EventoId == eventoId))
                                 .ToListAsync();
        }

        public async Task RemoverListaEsperaAsync(ListaEspera listaEspera)
        {
            _context.ListasEspera.Remove(listaEspera);
            await _context.SaveChangesAsync();
        }

        public async Task<Evento> GetByIdAsync(int eventoId)
        {
            return await _context.Eventos.FindAsync(eventoId);
        }

        public async Task UpdateAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Evento>> FindAsync(Expression<Func<Evento, bool>> predicate)
        {
            return await _context.Eventos
                .Where(predicate)
                .ToListAsync();
        }
        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            return await _context.Eventos.ToListAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId)
        {
            return await _context.Eventos
                .FirstOrDefaultAsync(e => e.EventoId == eventoId);
        }

        public async Task<bool> UpdateEventoAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }


        public async Task SaveAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Evento>> BuscarEventosPorCategoriaAsync(int categoriaId)
        {
            return await _context.Eventos
                .Where(e => e.CategoriaId == categoriaId)
                .Include(e => e.Organizacao) // Inclui dados relacionados, se necessário.
                .ToListAsync();
        }

        // Implementação da busca por nome no banco de dados
        public async Task<IEnumerable<Evento>> BuscarEventosPorNomeAsync(string nome)
        {
            return await _context.Eventos
                .Where(e => e.NomeEvento.Contains(nome)) // Busca eventos com o nome que contenha o termo fornecido
                .ToListAsync();
        }

        // Implementação da busca por localização no banco de dados
        public async Task<IEnumerable<Evento>> BuscarEventosPorLocalizacaoAsync(string cidade, string estado)
        {
            var query = _context.Eventos
                                .Include(e => e.Endereco) // Inclui o endereço no resultado da consulta
                                .AsQueryable();

            // Filtro por cidade, caso seja fornecida
            if (!string.IsNullOrEmpty(cidade))
            {
                query = query.Where(e => e.Endereco.Cidade.Contains(cidade));
            }

            // Filtro por estado, caso seja fornecido
            if (!string.IsNullOrEmpty(estado))
            {
                query = query.Where(e => e.Endereco.Estado.Contains(estado));
            }

            return await query.ToListAsync();
        }

        // Método para buscar eventos com múltiplos filtros
        public async Task<IEnumerable<Evento>> BuscarEventosComFiltrosAsync(
            string nome, string categoria, string cidade, string estado)
        {
            var query = _context.Eventos
                                .Include(e => e.Endereco) // Inclui o Endereço
                                .Include(e => e.Categoria) // Inclui a Categoria (ajuste conforme sua estrutura)
                                .AsQueryable();

            // Filtro por nome
            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(e => e.NomeEvento.Contains(nome));
            }

            // Filtro por categoria (ajustar conforme seu relacionamento de categoria)
            if (!string.IsNullOrEmpty(categoria))
            {
                query = query.Where(e => e.Categoria.Nome.Contains(categoria)); // Ajuste para o nome ou o relacionamento correto
            }

            // Filtro por cidade
            if (!string.IsNullOrEmpty(cidade))
            {
                query = query.Where(e => e.Endereco.Cidade.Contains(cidade));
            }

            // Filtro por estado
            if (!string.IsNullOrEmpty(estado))
            {
                query = query.Where(e => e.Endereco.Estado.Contains(estado));
            }

            return await query.ToListAsync();
        }

        public async Task<int> ObterNumeroDeInscritosAsync(int eventoId)
        {
            return await _context.Inscricoes
                .Where(i => i.EventoId == eventoId && i.Status != "cancelado") // Filtrando inscrições confirmadas
                .CountAsync();
        }

        public async Task<double> ObterTaxaCancelamentoAsync(int eventoId)
        {
            // Obtém o total de inscritos
            var totalInscritos = await _context.Inscricoes
                .Where(i => i.EventoId == eventoId)
                .CountAsync();

            // Obtém o total de cancelamentos
            var totalCancelamentos = await _context.Inscricoes
                .Where(i => i.EventoId == eventoId && i.Status == "cancelado")
                .CountAsync();

            // Retorna a taxa de cancelamento
            if (totalInscritos == 0) return 0; // Evita divisão por zero
            return (double)totalCancelamentos / totalInscritos * 100;
        }

    }
}
