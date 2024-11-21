using EventPlanApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class PermissionService : IPermissionService
    {
        public Task<bool> CheckUserPermissionAsync(ClaimsPrincipal user, string permission)
        {
            // Exemplo de lógica para verificar permissões em claims
            var userPermissions = user.FindFirst("permissions")?.Value;
            if (userPermissions != null && userPermissions.Contains(permission))
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
