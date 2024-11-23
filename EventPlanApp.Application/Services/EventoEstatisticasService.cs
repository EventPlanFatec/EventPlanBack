using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class EventoEstatisticasService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoEstatisticasService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<EventoEstatisticasDto> ObterEstatisticasEventoAsync(int eventoId)
        {
            // Obtém as informações do evento
            var evento = await _eventoRepository.GetByIdAsync(eventoId);
            if (evento == null)
                throw new Exception("Evento não encontrado!");

            // Obtém a taxa de cancelamento
            var taxaCancelamento = await _eventoRepository.ObterTaxaCancelamentoAsync(eventoId);

            return new EventoEstatisticasDto
            {
                NomeEvento = evento.NomeEvento,
                TotalInscritos = await _eventoRepository.ObterNumeroDeInscritosAsync(eventoId),
                TotalCancelamentos = (int)(taxaCancelamento * evento.TotalInscritos / 100),
                TaxaCancelamento = taxaCancelamento
            };
        }
    }
}
