using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.DTOs
{
    public class TicketDto
    {
        public int IngressoId { get; set; }
        public decimal Valor { get; set; }
        public string NomeEvento { get; set; }
        public bool Vip { get; set; }
        public int QuantidadeDisponivel { get; set; }
    }
}
