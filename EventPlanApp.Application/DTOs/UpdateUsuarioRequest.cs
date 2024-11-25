using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.DTOs
{
    public class UpdateUsuarioRequest
    {
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public Guid? RoleId { get; set; }
        public string? Tema { get; set; } // Exemplo: "light" ou "dark"
    }
}
