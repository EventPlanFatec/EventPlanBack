using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class PurchaseRequest
    {
        public int EventoId { get; set; }
        public decimal Valor { get; set; }
        public string QRCode { get; set; }
        public DateTime Data { get; set; }
        public bool Vip { get; set; }
        public Guid UsuarioFinalId { get; set; }
        public string Email { get; set; }
    }
}
