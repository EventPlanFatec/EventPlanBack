namespace EventPlanApp.Domain.Interfaces
{
    public interface IFirebaseRepository
    {
        Task<List<Dictionary<string, object>>> GetAllDocumentsAsync(string collectionName);
        Task<Dictionary<string, object>> GetDocumentByIdAsync(string collectionName, string documentId);
        Task UpdateDocumentAsync(string collectionName, string documentId, Dictionary<string, object> data);
        Task DeleteDocumentAsync(string collectionName, string documentId);
    }
}
