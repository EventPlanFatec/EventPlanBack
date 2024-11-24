﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.DTOs
{
    public class HistoricoDeEventoDto
    {
        public int EventoId { get; set; }
        public string NomeEvento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int NumeroDeInscritos { get; set; }
        public int NumeroDePresentes { get; set; }
        public double MediaDeAvaliacoes { get; set; }
        public int TotalInscritos { get; set; }
        public decimal TaxaDePresenca { get; set; }
        public decimal AvaliacaoMedia { get; set; }


    }
}