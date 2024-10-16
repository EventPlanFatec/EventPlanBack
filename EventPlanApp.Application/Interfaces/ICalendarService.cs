using EventPlanApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface ICalendarService
    {
        object Events { get; }

        Task<bool> AddEventToCalendarAsync(EventoDto eventoDto, string userId);
    }
}
