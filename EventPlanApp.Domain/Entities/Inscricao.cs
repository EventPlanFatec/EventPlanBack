using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class Inscricao
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public int UsuarioFinalId { get; set; }
        public DateTime DataInscricao { get; set; }
        public string Status { get; set; } // "confirmado", "cancelado", etc.

        // Navegação para Evento e UsuarioFinal
        public Evento Evento { get; set; }
        public UsuarioFinal UsuarioFinal { get; set; }
    }
}
