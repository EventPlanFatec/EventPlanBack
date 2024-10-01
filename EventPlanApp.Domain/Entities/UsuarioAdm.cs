using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class UsuarioAdm
    {
        public int AdmId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string NomeUsuario { get; set; }
        public string Telefone { get; set; }

        public ICollection<Organizacao> Organizacoes { get; set; }
    }

}
