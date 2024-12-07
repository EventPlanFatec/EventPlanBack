using EventPlanApp.Domain.Interfaces;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class FirebaseRepository : IFirebaseRepository
    {
        private readonly FirestoreDb _firestoreDb;

        public FirebaseRepository(FirebaseDbContext firebaseDbContext)
        {
            _firestoreDb = firebaseDbContext.GetFirestoreDb();
        }

        public async Task<List<Dictionary<string, object>>> GetAllDocumentsAsync(string collectionName)
        {
            var snapshot = await _firestoreDb.Collection(collectionName).GetSnapshotAsync();
            var documents = new List<Dictionary<string, object>>();

            foreach (var document in snapshot.Documents)
            {
                var documentData = document.ToDictionary();
                documents.Add(documentData);
            }

            return documents;
        }

        public async Task<Dictionary<string, object>> GetDocumentByIdAsync(string collectionName, string documentId)
        {
            var documentRef = _firestoreDb.Collection(collectionName).Document(documentId);
            var snapshot = await documentRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                return snapshot.ToDictionary();
            }

            return null;
        }

        public async Task UpdateDocumentAsync(string collectionName, string documentId, Dictionary<string, object> data)
        {
            var documentRef = _firestoreDb.Collection(collectionName).Document(documentId);
            await documentRef.SetAsync(data, SetOptions.MergeAll);
        }

        public async Task DeleteDocumentAsync(string collectionName, string documentId)
        {
            var documentRef = _firestoreDb.Collection(collectionName).Document(documentId);
            await documentRef.DeleteAsync();
        }
    }
}
