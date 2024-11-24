using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class TaxaServicoConfig
    {
        public int Id { get; set; }
        public int EventoId { get; set; } // Se for configurado por evento
        public decimal? TaxaFixa { get; set; } // Se for uma taxa fixa
        public decimal? TaxaPercentual { get; set; } // Se for uma taxa percentual
    }
}
