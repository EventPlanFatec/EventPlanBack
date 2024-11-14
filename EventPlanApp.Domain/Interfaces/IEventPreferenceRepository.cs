using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IEventPreferenceRepository
    {
        Task<bool> SavePreferencesAsync(EventPreference preferences);
        Task<EventPreference> GetPreferencesByUserIdAsync(int userId);
    }
}
