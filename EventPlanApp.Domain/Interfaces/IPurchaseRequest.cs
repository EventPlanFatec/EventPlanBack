using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IPurchaseRequest
    {
        /// <summary>
        /// Gera o resumo da compra com base no evento e ingressos selecionados.
        /// </summary>
        /// <param name="eventoId">ID do evento.</param>
        /// <param name="ingressos">Lista de ingressos.</param>
        /// <returns>Resumo da compra.</returns>
        Task<object> GerarResumoCompra(int eventoId, IEnumerable<Ingresso> ingressos);
    }
}
