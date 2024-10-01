using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class UsuarioFinal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string DDD { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Preferencias01 { get; set; }
        public string Preferencias02 { get; set; }
        public string Preferencias03 { get; set; }

        public ICollection<Ingresso> Ingressos { get; set; }
    }
}
