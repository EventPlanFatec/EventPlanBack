using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Google.Rpc.Context.AttributeContext.Types;

public class UsuarioAdmController : ControllerBase
{
    private readonly IAuditService _auditService;
    private readonly IUsuarioAdmService _usuarioAdmService;  // Serviço para manipular usuários

    public UsuarioAdmController(IAuditService auditService, IUsuarioAdmService usuarioAdmService)
    {
        _auditService = auditService;
        _usuarioAdmService = usuarioAdmService;
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
}
