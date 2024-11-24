using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.Services;
using EventPlanApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    public class IngressoController : Controller
    {
        private readonly IIngressoService _ingressoService;

        // Construtor para injeção de dependência
        public IngressoController(IIngressoService ingressoService)
        {
            _ingressoService = ingressoService ?? throw new ArgumentNullException(nameof(ingressoService));
        }
        [HttpPost]
        public async Task<IActionResult> CriarIngresso([FromBody] Ingresso ingresso)
        {
            if (ingresso == null)
            {
                return BadRequest("Ingresso inválido.");
            }

            // Usando a instância do _ingressoService corretamente
            var ingressoCriado = await _ingressoService.CriarIngressoAsync(ingresso);

            if (ingressoCriado == null)
            {
                return BadRequest("Não foi possível criar o ingresso.");
            }

            // Retorna resposta com status 201 e a localização do novo ingresso
            return CreatedAtAction(nameof(GetIngressoById), new { id = ingressoCriado.IngressoId }, ingressoCriado);
        }

        // Método para obter ingresso por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngressoById(int id)
        {
            var ingresso = await _ingressoService.ObterIngressoPorIdAsync(id);

            if (ingresso == null)
            {
                return NotFound();
            }

            return Ok(ingresso);
        }
    }
}
