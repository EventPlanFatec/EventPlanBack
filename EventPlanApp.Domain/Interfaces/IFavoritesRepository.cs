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

        Task<bool> RemoveFavoriteAsync(string userId, int eventoId);

        Task<List<Favorite>> GetFavoritosByUsuarioIdAsync(int usuarioId);
        Task AddFavoritoAsync(Favorite favorite);
        Task RemoveFavoritoAsync(int usuarioId, int eventoId);
        Task<bool> EventoJaFavoritoAsync(int usuarioId, int eventoId);
    }

}
