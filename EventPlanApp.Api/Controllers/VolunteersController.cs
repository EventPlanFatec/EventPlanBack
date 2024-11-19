using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : Controller
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteersController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        // POST /api/volunteers
        [HttpPost]
        public async Task<IActionResult> RegisterVolunteer([FromBody] VolunteerDto volunteerDto)
        {
            if (volunteerDto == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var volunteer = await _volunteerService.RegisterVolunteerAsync(volunteerDto);
                return CreatedAtAction(nameof(RegisterVolunteer), new { id = volunteer.Id }, volunteer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVolunteerAsync(int id, [FromBody] VolunteerDto volunteerDto)
        {
            if (volunteerDto == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                // Chama o serviço para atualizar o voluntário
                var updatedVolunteer = await _volunteerService.UpdateVolunteerAsync(id, volunteerDto);

                if (updatedVolunteer == null)
                {
                    return NotFound("Volunteer not found.");
                }

                return Ok(updatedVolunteer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVolunteerAsync(int id)
        {
            // Chama o serviço para excluir o voluntário
            var result = await _volunteerService.DeleteVolunteerAsync(id);

            if (!result)
            {
                return NotFound(new { message = "Voluntário não encontrado." });
            }

            return NoContent(); // Retorna 204 No Content se a remoção for bem-sucedida
        }
    }
}
