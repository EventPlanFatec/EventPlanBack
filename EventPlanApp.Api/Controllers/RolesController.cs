using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleRequest roleRequest)
        {
            if (roleRequest == null || string.IsNullOrEmpty(roleRequest.RoleName) || roleRequest.Permissions == null)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                await _roleService.CreateRoleAsync(roleRequest);
                return Ok("Função criada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar função: {ex.Message}");
            }
        }
    }
}
