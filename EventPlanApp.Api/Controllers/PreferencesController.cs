using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.Services;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Infra.Data;
using Google;
using Google.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PreferencesController : Controller
{
    private readonly EventPlanContext _context;
    private readonly UserPreferencesValidator _validator;
    private readonly IEventPreferenceService _preferenceService;

    public PreferencesController(EventPlanContext context, UserPreferencesValidator validator, IEventPreferenceService preferenceService)
    {
        _context = context;
        _validator = validator;
        _preferenceService = preferenceService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserPreferences preferences)
    {
        // Validando as preferências
        var validationResult = _validator.Validate(preferences);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        // Verificando se as preferências já existem
        var existingPreferences = await _context.UserPreferences
            .FirstOrDefaultAsync(up => up.UserId == preferences.UserId);

        if (existingPreferences != null)
        {
            // Atualizando as preferências se já existirem
            existingPreferences.EventType = preferences.EventType;
            existingPreferences.Location = preferences.Location;
            existingPreferences.PriceRange = preferences.PriceRange;
            _context.UserPreferences.Update(existingPreferences);
        }
        else
        {
            // Adicionando as novas preferências
            await _context.UserPreferences.AddAsync(preferences);
        }

        // Salvando no banco de dados
        await _context.SaveChangesAsync();

        return Ok(new { message = "Preferências salvas com sucesso." });
    }
    [HttpPost("save")]
    public async Task<IActionResult> SavePreferences([FromBody] UserPreferences preferences)
    {
        // Validando as preferências
        var validationResult = _validator.Validate(preferences);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        // Verificando se as preferências já existem
        var existingPreferences = await _context.UserPreferences
            .FirstOrDefaultAsync(up => up.UserId == preferences.UserId);

        if (existingPreferences != null)
        {
            // Atualizando as preferências se já existirem
            existingPreferences.EventType = preferences.EventType;
            existingPreferences.Location = preferences.Location;
            existingPreferences.PriceRange = preferences.PriceRange;
            _context.UserPreferences.Update(existingPreferences);
        }
        else
        {
            // Adicionando as novas preferências
            await _context.UserPreferences.AddAsync(preferences);
        }

        // Salvando no banco de dados
        await _context.SaveChangesAsync();

        return Ok(new { message = "Preferências salvas com sucesso." });
    }
    [HttpPost("save-service")]
    public async Task<IActionResult> SavePreferencesUsingService([FromBody] EventPreference preferences)
    {
        if (preferences == null)
        {
            return BadRequest("Preferências inválidas.");
        }

        // Utilizando o serviço para salvar as preferências
        var result = await _preferenceService.SavePreferencesAsync(preferences);

        if (result)
        {
            return Ok("Preferências salvas com sucesso.");
        }
        else
        {
            return Conflict("Já existem preferências salvas para este usuário.");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePreferences([FromBody] EventPreference preferences)
    {
        if (!ModelState.IsValid)
            return BadRequest("Dados inválidos.");

        // Chamar o serviço para salvar ou atualizar as preferências
        var success = await _preferenceService.SavePreferencesAsync(preferences);

        if (!success)
            return BadRequest("Falha ao salvar as preferências.");

        return Ok(new { message = "Preferências atualizadas com sucesso." });
    }
}
