using EventPlanApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IEventoEstatisticasService
    {
        Task<EventoEstatisticasDto> ObterEstatisticasPorEventoAsync(int eventoId);
    }
}
