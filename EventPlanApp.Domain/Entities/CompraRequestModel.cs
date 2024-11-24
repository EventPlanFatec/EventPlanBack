using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class CompraRequestModel
    {
        /// <summary>
        /// ID do evento associado à compra.
        /// </summary>
        public int EventoId { get; set; }

        /// <summary>
        /// Lista de IDs de ingressos selecionados para a compra.
        /// </summary>
        public List<int> IngressoIds { get; set; }

        /// <summary>
        /// Quantidade de ingressos por tipo.
        /// </summary>
        public Dictionary<int, int> QuantidadePorIngresso { get; set; } = new Dictionary<int, int>();
    }
}
