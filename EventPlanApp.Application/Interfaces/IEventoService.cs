﻿using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Application.Interfaces
{
    public interface IEventoService : IService<EventoDto>
    {
        Task<bool> InscreverNaListaDeEspera(int eventoId, InscricaoListaEsperaDTO inscricao);
        Task RemoverInscricaoAsync(int usuarioId, int eventoId);
    }

}
