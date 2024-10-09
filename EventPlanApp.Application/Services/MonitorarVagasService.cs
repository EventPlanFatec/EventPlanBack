using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Interfaces;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class VagasMonitorService
    {
        private readonly IEmailService _emailService;
        private readonly IEventoRepository _eventoRepository;

        public VagasMonitorService(IEmailService emailService, IEventoRepository eventoRepository)
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
                        var mensagem = new MensagemEmail
                        {
                            Destinatario = usuario.Email,
                            Assunto = "Vaga Disponível!",
                            Conteudo = $"Olá {usuario.Nome}, uma vaga foi liberada para o evento {evento.NomeEvento}."
                        };

                        await _emailService.SendEmailAsync(mensagem);
                    }
                }
            }
        }
    }
}
