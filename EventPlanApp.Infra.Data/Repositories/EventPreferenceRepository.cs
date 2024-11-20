using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using Microsoft.EntityFrameworkCore;

public class EventPreferenceRepository : IEventPreferenceRepository
{
    private readonly EventPlanContext _context;

    public async Task<bool> SavePreferencesAsync(EventPreference preferences)
    {
        // Verificar se já existe uma preferência para o usuário
        var existingPreference = await _context.EventPreferences
            .FirstOrDefaultAsync(p => p.UserId == preferences.UserId);

        if (existingPreference != null)
        {
            // Atualizar as preferências existentes
            existingPreference.EventType = preferences.EventType;
            existingPreference.Location = preferences.Location;
            existingPreference.MinPrice = preferences.MinPrice;
            existingPreference.MaxPrice = preferences.MaxPrice;

            _context.EventPreferences.Update(existingPreference);
        }
        else
        {
            // Adicionar nova preferência
            _context.EventPreferences.Add(preferences);
        }

        await _context.SaveChangesAsync();
        return true;
    }

    // Implementando o método GetPreferencesByUserIdAsync
    public async Task<EventPreference> GetPreferencesByUserIdAsync(int userId)
    {
        return await _context.EventPreferences
            .FirstOrDefaultAsync(p => p.UserId == userId);
    }
}
