using System;

namespace EventPlanApp.Domain.Entities
{
    public class TaxaServicoConfig
    {
        public int Id { get; set; }
        public int EventoId { get; set; } // Chave estrangeira para o evento
        public Evento Evento { get; set; } // Relacionamento com Evento

        public decimal? TaxaFixa { get; set; } // Se for uma taxa fixa
        public decimal? TaxaPercentual { get; set; } // Se for uma taxa percentual

        public TaxaServicoConfig(int eventoId, decimal? taxaFixa, decimal? taxaPercentual)
        {
            if (taxaFixa == null && taxaPercentual == null)
                throw new ArgumentException("Pelo menos uma taxa deve ser configurada: fixa ou percentual.");

            EventoId = eventoId;
            TaxaFixa = taxaFixa;
            TaxaPercentual = taxaPercentual;
        }

        public void AtualizarTaxa(decimal? taxaFixa, decimal? taxaPercentual)
        {
            if (taxaFixa == null && taxaPercentual == null)
                throw new ArgumentException("Pelo menos uma taxa deve ser configurada: fixa ou percentual.");

            TaxaFixa = taxaFixa;
            TaxaPercentual = taxaPercentual;
        }
    }
}
