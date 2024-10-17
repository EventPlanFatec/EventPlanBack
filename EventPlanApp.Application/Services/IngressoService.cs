﻿using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public interface IIngressoService
    {
        Task<bool> CreateTicket(IngressoDto ingressoDto);
        Task<IEnumerable<TicketDto>> GetAllTicketsAsync();
    }

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
