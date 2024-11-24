using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.Services;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Google.Rpc.Context.AttributeContext.Types;

public class UsuarioAdmController : ControllerBase
{
    private readonly IAuditService _auditService;
    private readonly IUsuarioAdmService _usuarioAdmService;  // Serviço para manipular usuários
    private readonly IAuditLogRetentionService _auditLogRetentionService;

    public UsuarioAdmController(IAuditService auditService, IUsuarioAdmService usuarioAdmService, IAuditLogRetentionService auditLogRetentionService)
    {
        _auditService = auditService;
        _usuarioAdmService = usuarioAdmService;
        _auditLogRetentionService = auditLogRetentionService;
        _auditLogRetentionService = auditLogRetentionService;
    }

    [HttpGet("{id-userAdm-get}")]
    public async Task<ActionResult<UsuarioAdm>> ObterUsuarioAdmPorId(int id)
    {
        var usuarioAdm = await _usuarioAdmService.ObterPorIdAsync(id);
        if (usuarioAdm == null)
        {
            return NotFound();
        }
        return Ok(usuarioAdm);
    }

    [HttpPost("id-userAdm-criar")]
    public async Task<ActionResult> CriarUsuarioAdm([FromBody] UsuarioAdm usuarioAdm)
    {
        await _usuarioAdmService.CriarUsuarioAdmAsync(usuarioAdm); // Agora, o método deve estar definido corretamente
        return CreatedAtAction(nameof(ObterUsuarioAdmPorId), new { id = usuarioAdm.AdmId }, usuarioAdm);
    }

    [HttpPut("{id-userAdm-Atualizar}")]
    public async Task<ActionResult> AtualizarUsuarioAdm(int id, [FromBody] UsuarioAdm usuarioAdm)
    {
        if (id != usuarioAdm.AdmId)
        {
            return BadRequest();
        }

        await _usuarioAdmService.AtualizarUsuarioAdmAsync(usuarioAdm);
        return NoContent();
    }

    [HttpDelete("{id-userAdm-Delete}")]
    public async Task<ActionResult> ExcluirUsuarioAdm(int id)
    {
        await _usuarioAdmService.ExcluirUsuarioAdmAsync(id);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> SetRetentionPolicy(AuditLogRetentionPolicy policy)
    {
        // Aplicar a política de retenção de logs
        await _auditLogRetentionService.ApplyRetentionPolicy(policy);

        return RedirectToAction("RetentionPolicyPage");
    }
}
