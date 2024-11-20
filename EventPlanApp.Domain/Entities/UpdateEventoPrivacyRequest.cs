using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class UpdateEventoPrivacyRequest
    {
        // Define a privacidade do evento como 'Público' ou 'Privado'
        public bool Privacidade { get; set; }

        // Se necessário, você pode adicionar mais campos (por exemplo, lista de convidados)
        public List<string> Convidados { get; set; }  // Caso precise para eventos privados
    }
}
