using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IAuditService
    {
        Task RegistrarAcaoAsync(int usuarioAdmId, string tipoAcao, string descricao, string conteudoAlteradoAntes, string conteudoAlteradoDepois, string ipEndereco);
    }
}
