using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizacaoService _organizacaoService;

        public OrganizationsController(IOrganizacaoService organizacaoService)
        {
            _organizacaoService = organizacaoService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrganizacaoDto organizacaoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _organizacaoService.RegisterAsync(organizacaoDto);

            if (result.Success)
            {
                return CreatedAtAction(nameof(Post), new { id = result.OrganizacaoId }, result);
            }

            return BadRequest(result.Message);
        }
    }
}

