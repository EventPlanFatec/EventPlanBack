using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.ViewModels;

namespace EventPlanApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]  // Garante que apenas administradores possam acessar este endpoint
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpGet("logs")]
        public async Task<IActionResult> GetAuditLogs([FromQuery] AuditLogFilter filter)
        {
            if (filter == null)
                return BadRequest("Filtros são obrigatórios.");

            var logs = await _auditLogService.GetAuditLogsAsync(filter);

            if (logs == null || !logs.Any())
                return NotFound("Nenhum registro encontrado.");

            return Ok(logs);
        }
    }
}

