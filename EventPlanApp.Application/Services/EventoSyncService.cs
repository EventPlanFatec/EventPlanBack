using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Globalization;

namespace EventPlanApp.Application.Services
{
    public class EventoSyncService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly FirebaseDbContext _firebaseDbContext;

        public EventoSyncService(IEventoRepository eventoRepository, FirebaseDbContext firebaseDbContext)
        {
            _eventoRepository = eventoRepository;
            _firebaseDbContext = firebaseDbContext;
        }

        public async Task SyncEventosFromFirebaseToSqlServerAsync()
        {
            var eventosFromFirebase = await _firebaseDbContext.GetAllDocumentsAsync("Eventos");

            foreach (var doc in eventosFromFirebase)
            {
                var evento = new Evento
                {
                    Nome = doc.ContainsKey("nome") ? doc["nome"].ToString() : "Nome não informado",
                    Local = doc.ContainsKey("local") ? doc["local"].ToString() : "Local não informado",
                    Descricao = doc.ContainsKey("description") ? doc["description"].ToString() : "Descrição não informada",
                    Data = doc.ContainsKey("date") ? ParseDate(doc["date"].ToString()) : "01/01/2024 00:00",
                    ValorMin = doc.ContainsKey("price") ? decimal.Parse(doc["price"].ToString(), CultureInfo.InvariantCulture).ToString("0.00", CultureInfo.InvariantCulture) : "0.00",
                    Tipo = doc.ContainsKey("type") ? doc["type"].ToString() : "Tipo não informado",
                    Img = doc.ContainsKey("img") ? doc["img"].ToString() : "https://default-image-url.com/placeholder.png",
                    ImgBanner = doc.ContainsKey("imgBanner") ? doc["imgBanner"].ToString() : "https://default-image-url.com/placeholder-banner.png"
                };

                await _eventoRepository.Add(evento);
            }
        }

        private string ParseDate(string dateString)
        {
            var dateParts = dateString.Split(" - ");
            if (dateParts.Length > 1)
            {
                return dateParts[0] + " " + dateParts[1];
            }
            return "01/01/2024 00:00";
        }
    }
}
