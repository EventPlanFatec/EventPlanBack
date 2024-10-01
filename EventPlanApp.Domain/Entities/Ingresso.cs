using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class Ingresso
    {
        [Key]
        public int IngressoId { get; set; }

        [Required(ErrorMessage = "O valor do ingresso é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor do ingresso deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O QR Code é obrigatório.")]
        [StringLength(200, ErrorMessage = "O QR Code não pode exceder 200 caracteres.")]
        public string QRCode { get; set; }

        [Required(ErrorMessage = "O nome do evento é obrigatório.")]
        public string NomeEvento { get; set; }

        [Required(ErrorMessage = "A data do ingresso é obrigatória.")]
        public DateTime Data { get; set; }

        public bool VIP { get; set; }
    }

}
