using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioFinalRepository _usuarioFinalRepository;
        private readonly EventPlanContext _context;

        public UsuarioController(IUsuarioFinalRepository usuarioFinalRepository, EventPlanContext context)
        {
            _usuarioFinalRepository = usuarioFinalRepository;
            _context = context;
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


        [HttpPost("create")]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUserRequest request)
        {
            if (request == null)
                return BadRequest("Dados inválidos.");

            // Validar se todos os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(request.Email))
                return BadRequest("O e-mail é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.Nome))
                return BadRequest("O nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(request.Sobrenome))
                return BadRequest("O sobrenome é obrigatório.");

            if (request.DataNascimento == default)
                return BadRequest("A data de nascimento é obrigatória.");

            // Verificar se o e-mail já está registrado
            var existingUser = await _context.Usuarios
                .AnyAsync(u => u.Email == request.Email);
            if (existingUser)
                return Conflict("Este e-mail já está registrado.");

            try
            {
                // Criar o objeto de endereço utilizando o construtor da classe Endereco
                var endereco = new Endereco(
                    request.Endereco.TipoLogradouro,
                    request.Endereco.Logradouro,
                    request.Endereco.NumeroCasa,
                    request.Endereco.Bairro,
                    request.Endereco.Cidade,
                    request.Endereco.Estado,
                    request.Endereco.CEP
                );

                // Criar o usuário com o endereço
                var usuario = new UsuarioFinal(
                    request.Nome,
                    request.Sobrenome,
                    endereco,
                    request.Email,
                    request.Telefone,
                    request.Ddd,
                    request.DataNascimento
                );

                // Salvar o usuário no banco de dados
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // Enviar e-mail de boas-vindas (pseudo código)
                // await EmailService.SendWelcomeEmail(usuario.Email);

                return Ok(new { message = "Usuário criado com sucesso!" });
            }
            catch (Exception ex)
            {
                // Log de erro pode ser adicionado aqui
                return StatusCode(500, $"Erro ao criar o usuário: {ex.Message}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUsuario(Guid id, [FromBody] UpdateUsuarioRequest request)
        {
            if (request == null)
                return BadRequest("Os dados enviados são inválidos.");

            // Buscar o usuário existente no banco de dados
            var usuario = await _context.Usuarios
                .Include(u => u.Role) // Carregar dados relacionados à Role
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            try
            {
                // Atualizar as propriedades do usuário
                if (!string.IsNullOrWhiteSpace(request.Nome))
                    usuario.SetNome(request.Nome);

                if (!string.IsNullOrWhiteSpace(request.Sobrenome))
                    usuario.SetSobrenome(request.Sobrenome);

                if (!string.IsNullOrWhiteSpace(request.Email))
                    usuario.SetEmail(request.Email);

                if (request.RoleId.HasValue)
                    usuario.AssignRole(request.RoleId.Value);

                // Atualizar o tema, caso informado
                if (!string.IsNullOrWhiteSpace(request.Tema))
                    usuario.SetTema(request.Tema);

                // Salvar mudanças no banco de dados
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Usuário atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                // Log de erro pode ser adicionado aqui
                return StatusCode(500, $"Erro ao atualizar o usuário: {ex.Message}");
            }
        }

    }
}
