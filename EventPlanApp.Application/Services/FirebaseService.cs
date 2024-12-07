using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class FirebaseService : IFirebaseService
    {
        private readonly IFirebaseRepository _firebaseRepository;

        public FirebaseService(IFirebaseRepository firebaseRepository)
        {
            _firebaseRepository = firebaseRepository;
        }
        public async Task<List<Dictionary<string, object>>> GetEventosAsync()
        {
            return await _firebaseRepository.GetAllDocumentsAsync("Eventos");
        }

        public async Task<Dictionary<string, object>> GetEventoByIdAsync(string id)
        {
            return await _firebaseRepository.GetDocumentByIdAsync("Eventos", id);
        }

        public async Task UpdateEventoAsync(string id, Dictionary<string, object> eventoData)
        {
            await _firebaseRepository.UpdateDocumentAsync("Eventos", id, eventoData);
        }

        public async Task DeleteEventoAsync(string id)
        {
            await _firebaseRepository.DeleteDocumentAsync("Eventos", id);
        }
    }
}
