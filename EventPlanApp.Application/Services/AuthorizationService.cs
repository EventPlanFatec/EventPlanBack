using EventPlanApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public async Task<bool> CheckUserPermissionAsync(ClaimsPrincipal user)
        {
            // Simula a verificação de permissões (adicione lógica real)
            await Task.Delay(10); // Apenas para simular async
            var userPermissions = user.Claims
                .Where(c => c.Type == "Permission")
                .Select(c => c.Value);

            return userPermissions.Contains("RequiredPermission");
        }
    }
}
