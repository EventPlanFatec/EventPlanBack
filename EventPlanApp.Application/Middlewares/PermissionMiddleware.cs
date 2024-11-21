using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using EventPlanApp.Application.Services;
using EventPlanApp.Application.Interfaces;

namespace EventPlanApp.Application.Middlewares
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPermissionService _permissionService;

        public PermissionMiddleware(RequestDelegate next, IPermissionService permissionService)
        {
            _next = next;
            _permissionService = permissionService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var user = context.User;
            var requiredPermission = "RequiredPermission"; // Substitua pelo nome da permissão necessária

            var hasPermission = await _permissionService.CheckUserPermissionAsync(user, requiredPermission);
            if (!hasPermission)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Acesso negado: você não possui permissões suficientes.");
                return;
            }

            await _next(context);
        }
    }
}
