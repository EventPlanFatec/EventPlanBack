//using EventPlanApp.Application.Interfaces;
//using EventPlanApp.Domain.Entities;
//using FireSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EventPlanApp.Application.Services
//{
//    public class FirebaseService : IFirebaseService
//    {
//        private readonly FirebaseClient _firebaseClient;

//        public FirebaseService()
//        {
//            _firebaseClient = new FirebaseClient("https://yourfirebaseapp.firebaseio.com/");
//        }

//        public async Task AddEventToFirebase(Evento evento)
//        {
//            await _firebaseClient
//                .Child("Eventos")
//                .Child(evento.Id)
//                .PutAsync(evento);
//        }

//        public async Task UpdateEventInFirebase(Evento evento)
//        {
//            await _firebaseClient
//                .Child("Eventos")
//                .Child(evento.Id)
//                .PutAsync(evento);
//        }

//        public async Task DeleteEventFromFirebase(int eventoId)
//        {
//            await _firebaseClient
//                .Child("Eventos")
//                .Child(eventoId.ToString())
//                .DeleteAsync();
//        }
//    }
//}
