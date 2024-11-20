using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class EventPreferenceService : IEventPreferenceService
{
    private readonly IEventPreferenceRepository _repository;

    public EventPreferenceService(IEventPreferenceRepository repository)
    {
        _repository = repository;
    }

        public async Task<bool> SavePreferencesAsync(EventPreference preferences)
        {
            if (string.IsNullOrEmpty(preferences.EventType))
                throw new ArgumentException("O tipo de evento é obrigatório.");

            if (preferences.MinPrice < 0 || preferences.MaxPrice < preferences.MinPrice)
                throw new ArgumentException("A faixa de preço é inválida.");

            return await _repository.SavePreferencesAsync(preferences);
        }



    }
}
