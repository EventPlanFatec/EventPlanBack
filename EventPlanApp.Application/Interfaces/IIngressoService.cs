using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Services;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    
    public class IngressoService : IIngressoService
    {
        private readonly IIngressoRepository _ingressoRepository;

        public IngressoService(IIngressoRepository ingressoRepository)
        {
            _ingressoRepository = ingressoRepository;
        }

        public Task<bool> CreateTicket(IngressoDto ingressoDto)
        {
            throw new NotImplementedException();
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
