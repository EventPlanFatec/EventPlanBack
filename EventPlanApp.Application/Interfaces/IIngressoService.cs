using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IIngressoService
    {
        Task<bool> CreateTicket(IngressoDto ingressoDto);
        Task<IEnumerable<TicketDto>> GetAllTicketsAsync();
        Task<SalesReportDto> GetSalesReportAsync();
    }

    
}
