using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.DTOs
{
    public class RegistracaoResultadoDto
    {
        public bool Success { get; set; }
        public int OrganizacaoId { get; set; }
        public string Message { get; set; }
    }
}
