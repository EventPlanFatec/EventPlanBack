using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using EventPlanApp.Application.Interfaces;  // Interface para o serviço de auditoria

public class AuditMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAuditLogService _auditLogService;
    private readonly ILogger<AuditMiddleware> _logger;

    public AuditMiddleware(RequestDelegate next, IAuditLogService auditLogService, ILogger<AuditMiddleware> logger)
    {
        _next = next;
        _auditLogService = auditLogService;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Captura as informações de auditoria apenas para rotas específicas (como criação e edição)
        if (IsCriticalOperation(context))
        {
            var userId = context.User?.Identity?.Name;  // A identificação do usuário (ID ou nome)
            var actionType = context.Request.Method;    // Tipo de operação (POST para criação, PUT para edição, etc.)
            var timestamp = DateTime.UtcNow;            // Data e hora da ação
            var route = context.Request.Path;           // Rota da requisição

            // Registra as informações de auditoria
            await _auditLogService.RegisterAuditLogAsync(userId, actionType, route, timestamp);

            _logger.LogInformation($"Ação crítica registrada: {actionType} - {route} por {userId} em {timestamp}");
        }

        // Passa a requisição para o próximo middleware
        await _next(context);
    }

    // Verifica se a rota é uma operação crítica
    private bool IsCriticalOperation(HttpContext context)
    {
        // Defina rotas que representam operações críticas, como criação e edição
        var criticalPaths = new[] { "/usuarios/criar", "/usuarios/editar", "/configuracoes" };

        return criticalPaths.Any(path => context.Request.Path.StartsWithSegments(path));
    }
}
