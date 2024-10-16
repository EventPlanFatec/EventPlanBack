using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System.IO;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.DTOs;

namespace EventPlanApp.Application.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly Google.Apis.Calendar.v3.CalendarService _calendarService;

        public CalendarService()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Google.Apis.Calendar.v3.CalendarService.Scope.Calendar);
            }

            _calendarService = new Google.Apis.Calendar.v3.CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Calendar service",
            });
        }

        public object Events => throw new NotImplementedException();

        public async Task<bool> AddEventToCalendarAsync(EventoDto eventoDto, string userId)
        {
            if (!eventoDto.DataInicio.HasValue || !eventoDto.DataFim.HasValue)
            {
                throw new ArgumentException("Data de início e fim são obrigatórias");
            }

            var calendarEvent = new Event()
            {
                Summary = eventoDto.NomeEvento,
                Description = eventoDto.Descricao,
                Start = new EventDateTime()
                {
                    DateTime = eventoDto.DataInicio.Value.Add(eventoDto.HorarioInicio ?? TimeSpan.Zero),
                    TimeZone = "America/Sao_Paulo",
                },
                End = new EventDateTime()
                {
                    DateTime = eventoDto.DataFim.Value.Add(eventoDto.HorarioFim ?? TimeSpan.Zero),
                    TimeZone = "America/Sao_Paulo",
                }
            };

            try
            {
                var createdEvent = await _calendarService.Events.Insert(calendarEvent, "primary").ExecuteAsync();
                return createdEvent != null;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao criar evento: {ex.Message}");
                return false;
            }
            
        }
    }
}
