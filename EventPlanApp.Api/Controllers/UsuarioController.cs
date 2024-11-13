using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioFinalRepository _usuarioFinalRepository;

        public UsuarioController(IUsuarioFinalRepository usuarioFinalRepository)
        {
            _usuarioFinalRepository = usuarioFinalRepository;
        }

        // GET: api/usuario/tema/{id}
        [HttpGet("tema/{id}")]
        public async Task<ActionResult<UsuarioTemaDto>> GetTema(Guid id)
        {
            var usuario = await _usuarioFinalRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(new UsuarioTemaDto { Tema = usuario.Tema });
        }

        // PUT: api/usuario/tema/{id}
        [HttpPut("tema/{id}")]
        public async Task<IActionResult> UpdateTema(Guid id, [FromBody] UsuarioTemaDto temaDto)
        {
            if (temaDto == null || (temaDto.Tema != "light" && temaDto.Tema != "dark"))
            {
                return BadRequest("Tema inválido. Escolha entre 'light' ou 'dark'.");
            }

            var usuario = await _usuarioFinalRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            usuario.SetTema(temaDto.Tema);
            await _usuarioFinalRepository.UpdateAsync(usuario);

            return NoContent();
        }
    }
}
