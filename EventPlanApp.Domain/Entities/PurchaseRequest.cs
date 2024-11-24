using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class PurchaseRequest
    {
        public int EventoId { get; set; }
        public decimal Valor { get; set; }
        public string QRCode { get; set; }
        public DateTime Data { get; set; }
        public bool Vip { get; set; }
        public Guid UsuarioFinalId { get; set; }
        public string Email { get; set; }
        private readonly ITaxaServicoConfigRepository _taxaServicoConfigRepository;

        public PurchaseRequest(ITaxaServicoConfigRepository taxaServicoConfigRepository)
        {
            _taxaServicoConfigRepository = taxaServicoConfigRepository;
        }

        public async Task<PurchaseSummary> GerarResumoCompra(int eventoId, List<Ingresso> ingressos)
        {
            // Obtém a taxa de serviço configurada para o evento
            var taxaServico = await _taxaServicoConfigRepository.ObterTaxaServicoPorEventoAsync(eventoId);

            if (taxaServico == null)
                throw new InvalidOperationException("Taxa de serviço não configurada para este evento.");

            // Cria o resumo da compra
            var resumoCompra = new PurchaseSummary(eventoId, ingressos, taxaServico.TaxaFixa ?? 0); // Ou pode ser taxa percentual dependendo do caso

            return resumoCompra;
        }
    }
}
