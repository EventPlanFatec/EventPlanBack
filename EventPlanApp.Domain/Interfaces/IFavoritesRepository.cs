using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IFavoritesRepository
    {
        Task<bool> IsEventFavoritedByUserAsync(string userId, int eventoId);
        Task AddToFavoritesAsync(string userId, int eventoId);
        Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(string userId);
    }
}
