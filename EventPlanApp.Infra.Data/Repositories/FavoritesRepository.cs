using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Google;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class FavoritesRepository : IFavoritesRepository
    {
        private readonly FirestoreDb _firestoreDb;
        private readonly EventPlanContext _context;

        public FavoritesRepository(FirestoreDb firestoreDb, EventPlanContext context)
        {
            _firestoreDb = firestoreDb;
            _context = context;
        }

        public async Task<bool> IsEventFavoritedByUserAsync(string userId, int eventoId)
        {
            var userFavorites = _firestoreDb.Collection("users").Document(userId).Collection("favorites");
            var snapshot = await userFavorites.WhereEqualTo("eventId", eventoId).GetSnapshotAsync();

            // Verifica se a coleção contém documentos (se o evento está favoritado)
            return snapshot.Documents.Count > 0;
        }

        public async Task AddToFavoritesAsync(string userId, int eventoId)
        {
            var favoriteData = new { eventoId = eventoId };
            var userFavorites = _firestoreDb.Collection("users").Document(userId).Collection("favorites");
            await userFavorites.AddAsync(favoriteData);
        }
        public async Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(string userId)
        {
            return await _context.Favorites
                .Where(f => f.UserId == userId)
                .OrderBy(f => f.Evento.DataInicio)  // Ordenar pela data de início do evento
                .ToListAsync();
        }
        public async Task<bool> RemoveFavoriteAsync(string userId, int eventoId)
        {
            // Remove a relação entre o usuário e o evento
            var favorite = await _context.Favorites
                                          .FirstOrDefaultAsync(f => f.UserId == userId && f.EventoId == eventoId);
            if (favorite == null) return false;

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
