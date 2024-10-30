using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IIngressoRepository _ingressoRepository;
        private readonly IEmailService _emailService;
        private readonly IPdfGenerator _pdfGenerator;
        private readonly IEventoRepository _eventoRepository;

        public PurchaseService(IEventoRepository eventoRepository, IIngressoRepository ingressoRepository,
            IEmailService emailService, IPdfGenerator pdfGenerator)
        {
            _eventoRepository = eventoRepository;
            _ingressoRepository = ingressoRepository;
            _emailService = emailService;
            _pdfGenerator = pdfGenerator;
        }

        public async Task<PurchaseResult> ProcessPurchaseAsync(PurchaseRequest request)
        {
            // Validar disponibilidade
            var evento = await _eventoRepository.GetByIdAsync(request.EventoId);
            if (evento.LotacaoMaxima <= evento.LotacaoMaxima)
            {
                return new PurchaseResult(false, "Ingressos esgotados para este evento.");
            }

            // Criar o ingresso
            var ticket = new Ingresso(request.Valor, request.QRCode, evento.NomeEvento, request.Data, request.Vip);
            ticket.UsuarioFinalId = request.UsuarioFinalId;
            ticket.EventoId = evento.EventoId;

            await _ingressoRepository.AddAsync(ticket);

            // Gerar PDF
            var ticketPdf = _pdfGenerator.Generate(ticket);

            // Enviar por e-mail
            await _emailService.SendEmailWithAttachmentAsync(request.Email, "Seu Ingresso Digital", "Segue em anexo o seu ingresso.", ticketPdf);

            return new PurchaseResult(true, null);
        }
    }


}
