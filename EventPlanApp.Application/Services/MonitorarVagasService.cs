using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class VagasMonitorService
    {
        private readonly EmailService _emailService;
        private readonly IEventoRepository _eventoRepository;

        public VagasMonitorService(EmailService emailService, IEventoRepository eventoRepository)
        {
            _emailService = emailService;
            _eventoRepository = eventoRepository;
        }

        public async Task MonitorarVagasAsync()
        {
            var eventosLotados = await _eventoRepository.ObterEventosLotadosAsync();

            foreach (var evento in eventosLotados)
            {
                if (evento.VagasDisponiveis > 0)
                {
                    var usuariosListaEspera = await _eventoRepository.ObterUsuariosListaEsperaAsync(evento.EventoId);

                    foreach (var usuario in usuariosListaEspera)
                    {
                        await _emailService.SendEmailAsync(usuario.Email, "Vaga Disponível!",
                            $"Olá {usuario.Nome}, uma vaga foi liberada para o evento {evento.NomeEvento}.");

                    }
                }
            }
        }
    }

}
