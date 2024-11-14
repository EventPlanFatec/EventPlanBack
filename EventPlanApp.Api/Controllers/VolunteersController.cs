using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : Controller
    {
        private readonly VolunteerService _volunteerService;

        public VolunteersController(VolunteerService volunteerService)
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
    }
}
