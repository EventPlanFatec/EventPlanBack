using EventPlanApp.Domain.Interfaces;
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

        public FavoritesRepository(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        public async Task<bool> IsEventFavoritedByUserAsync(string userId, int eventId)
        {
            var userFavorites = _firestoreDb.Collection("users").Document(userId).Collection("favorites");
            var snapshot = await userFavorites.WhereEqualTo("eventId", eventId).GetSnapshotAsync();

            // Verifica se a coleção contém documentos (se o evento está favoritado)
            return snapshot.Documents.Count > 0;
        }

        public async Task AddToFavoritesAsync(string userId, int eventId)
        {
            var favoriteData = new { eventId = eventId };
            var userFavorites = _firestoreDb.Collection("users").Document(userId).Collection("favorites");
            await userFavorites.AddAsync(favoriteData);
        }
    }
}
