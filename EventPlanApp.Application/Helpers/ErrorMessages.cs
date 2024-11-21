using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Helpers
{
    public static class ErrorMessages
    {
        public static string AccessDenied = "Você não tem permissão para acessar esta funcionalidade.";
        public static string InsufficientPermissions = "Acesso negado: você não possui permissões suficientes.";
        public static string UnauthorizedAction = "Você não tem autorização para realizar esta ação.";

        // Outros casos de mensagens de erro
    }
}
