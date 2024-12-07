using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

namespace EventPlanApp.Infra.Data
{
    public class FirebaseDbContext
    {
        private readonly FirestoreDb _firestoreDb;

        public FirebaseDbContext()
        {
            string path = @"D:\Fatec\EventPlan\EventPlanBack\credentials\eventplan-30036-firebase-adminsdk-x9819-8a44fc39d8.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("eventplan-30036");
            _firestoreDb = db;
        }

        public FirestoreDb GetFirestoreDb()
        {
            return _firestoreDb;
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
