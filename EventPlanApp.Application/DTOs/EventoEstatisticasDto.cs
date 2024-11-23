using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.DTOs
{
    public class EventoEstatisticasDto
    {
        public string NomeEvento { get; set; }
        public int TotalInscritos { get; set; }
        public int TotalCancelamentos { get; set; }
        public double TaxaCancelamento { get; set; }
    }
}
