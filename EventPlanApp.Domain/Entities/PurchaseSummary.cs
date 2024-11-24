using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class PurchaseSummary
    {
        public int EventoId { get; set; }
        public List<Ingresso> Ingressos { get; set; }
        public decimal TotalIngressos { get; set; }
        public decimal TaxaServico { get; set; }
        public decimal TotalComTaxa { get; set; }

        public PurchaseSummary(int eventoId, List<Ingresso> ingressos, decimal taxaServico)
        {
            EventoId = eventoId;
            Ingressos = ingressos;
            TotalIngressos = Ingressos.Sum(i => i.Valor); // Soma dos valores dos ingressos
            TaxaServico = taxaServico; // Taxa de serviço configurada
            TotalComTaxa = CalcularTotalComTaxa(); // Calcula o total com a taxa incluída
        }

        private decimal CalcularTotalComTaxa()
        {
            return TotalIngressos + TaxaServico;
        }
    }

}
