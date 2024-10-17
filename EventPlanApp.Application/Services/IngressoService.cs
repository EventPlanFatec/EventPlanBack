using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    
    public class IngressoService : IIngressoService
    {
        private readonly IIngressoRepository _ingressoRepository;

        public IngressoService(IIngressoRepository ingressoRepository)
        {
            _ingressoRepository = ingressoRepository;
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
    }
}
