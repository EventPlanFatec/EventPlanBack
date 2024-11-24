using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using Google;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    
    public class IngressoService : IIngressoService
    {
        private readonly IIngressoRepository _ingressoRepository;
        private readonly EventPlanContext _context;
        

        public IngressoService(IIngressoRepository ingressoRepository, EventPlanContext context)
        {
            _ingressoRepository = ingressoRepository;
            _context = context;
        }

        public async Task<bool> CreateTicket(IngressoDto ingressoDto)
        {
            var ingresso = new Ingresso(
                ingressoDto.Valor,
                ingressoDto.QRCode,
                ingressoDto.NomeEvento,
                ingressoDto.Data,
                ingressoDto.Vip
            );

            await _ingressoRepository.AddAsync(ingresso);
            return true;
        }

        public async Task<SalesReportDto> GetSalesReportAsync()
        {
            var ingressos = await _ingressoRepository.GetAllAsync();
            var totalRevenue = ingressos.Sum(i => i.Valor); 
            var vipCount = ingressos.Count(i => i.Vip); 
            var generalCount = ingressos.Count(i => !i.Vip); 

            
            return new SalesReportDto
            {
                TotalRevenue = totalRevenue,
                VipTicketsSold = vipCount,
                GeneralTicketsSold = generalCount,
                TotalTicketsSold = vipCount + generalCount
            };
        }

        public async Task<IEnumerable<TicketDto>> GetAllTicketsAsync()
        {
            var ingressos = await _ingressoRepository.GetAllAsync();
            var ticketDtos = new List<TicketDto>();

            foreach (var ingresso in ingressos)
            {
            
                ticketDtos.Add(new TicketDto
                {
                    IngressoId = ingresso.IngressoId,
                    Valor = ingresso.Valor,
                    NomeEvento = ingresso.NomeEvento,
                    Vip = ingresso.Vip,
                    QuantidadeDisponivel = 10
                });
            }

            return ticketDtos;
        }

        public async Task<Ingresso> CriarIngressoAsync(Ingresso ingresso)
        {
            var taxaConfig = await _context.TaxaServicoConfig
                                           .FirstOrDefaultAsync(t => t.EventoId == ingresso.EventoId);

            if (taxaConfig != null)
            {
                decimal valorTaxa = 0;

                if (taxaConfig.TaxaFixa.HasValue)
                {
                    valorTaxa = taxaConfig.TaxaFixa.Value;
                }
                else if (taxaConfig.TaxaPercentual.HasValue)
                {
                    valorTaxa = ingresso.Valor * (taxaConfig.TaxaPercentual.Value / 100);
                }

                ingresso.ValorFinal = ingresso.Valor + valorTaxa;
            }
            else
            {
                ingresso.ValorFinal = ingresso.Valor; // Caso não tenha configuração de taxa
            }

            await _context.Ingressos.AddAsync(ingresso);
            await _context.SaveChangesAsync();

            return ingresso;
        }

        public async Task<Ingresso> ObterIngressoPorIdAsync(int id)
        {
            return await _context.Ingressos
                                 .Include(i => i.Evento) // Se precisar incluir o evento relacionado
                                 .FirstOrDefaultAsync(i => i.IngressoId == id);
        }

        public async Task<decimal> CalcularTaxaServico(int ingressoId)
        {
            // Lógica de cálculo da taxa de serviço
            var ingresso = await _context.Ingressos.FindAsync(ingressoId);
            if (ingresso == null)
            {
                throw new Exception("Ingresso não encontrado.");
            }

            // Exemplo de lógica para taxa de serviço
            return ingresso.Valor;  // Ajuste conforme necessário
        }
    }
}
