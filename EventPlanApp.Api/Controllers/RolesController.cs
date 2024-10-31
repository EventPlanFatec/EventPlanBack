using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleService roleService, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _roleService = roleService;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
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
        [HttpPut("users/{id}/role")]
        public async Task<IActionResult> AssignRoleToUser(Guid id, [FromBody] Guid roleId)
        {
            // Verifica se a função existe no repositório
            var roleExists = await _roleRepository.RoleExistsAsync(roleId);
            if (!roleExists)
            {
                return NotFound("Função não encontrada.");
            }

            // Verifica se o usuário existe no repositório
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // Atribui a função ao usuário (método AssignRole pode ser implementado na entidade UsuarioFinal)
            user.AssignRole(roleId);

            // Atualiza o usuário no repositório
            await _userRepository.UpdateAsync(user);

            return Ok("Função atribuída ao usuário com sucesso.");
        }
    }
}
