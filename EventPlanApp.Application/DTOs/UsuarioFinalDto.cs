using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.DTOs
{
    public class UsuarioFinalDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public EnderecoDto Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string DDD { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<IngressoDto> Ingressos { get; set; }

    }

}
