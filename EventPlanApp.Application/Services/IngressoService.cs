using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public interface IIngressoService
    {
        Task<bool> CreateTicket(IngressoDto ingressoDto);
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
                ingressoDto.Vip);

            await _ingressoRepository.AddAsync(ingresso);
            return true;
        }
    }
}
