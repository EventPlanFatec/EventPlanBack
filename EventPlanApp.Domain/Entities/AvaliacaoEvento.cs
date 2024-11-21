using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class AvaliacaoEvento
    {
        public int AvaliacaoEventoId { get; set; }
        public int EventoId { get; set; }
        public int UsuarioFinalId { get; set; }
        public decimal Avaliacao { get; set; }
    }
}
