using System;
using System.Collections.Generic;

namespace EventPlanApp.Domain.Entities
{
    public class Ingresso
    {
        public int IngressoId { get; private set; }
        public decimal Valor { get; private set; }
        public string QRCode { get; private set; }
        public string NomeEvento { get; private set; }
        public DateTime Data { get; private set; }
        public Guid UsuarioFinalId { get; set; }
        public virtual UsuarioFinal UsuarioFinal { get; set; }

        public int EventoId { get; set; } 
        public virtual Evento Evento { get; set; }

        public bool Vip { get; private set; }

        public Ingresso(decimal valor, string qrCode, string nomeEvento, DateTime data, bool vip)
        {
            ValidateDomain(valor, qrCode, nomeEvento, data, vip);
            IngressoId = new Random().Next(1, 1000); 
        }

        public Ingresso() { }

        private void ValidateDomain(decimal valor, string qrCode, string nomeEvento, DateTime data, bool vip)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(qrCode))
                throw new ArgumentException("O QRCode é obrigatório.");

            if (string.IsNullOrWhiteSpace(nomeEvento))
                throw new ArgumentException("O nome do evento é obrigatório.");

            if (data < DateTime.Now)
                throw new ArgumentException("A data não pode ser no passado.");

            Valor = valor;
            QRCode = qrCode;
            NomeEvento = nomeEvento;
            Data = data;
            Vip = vip;
        }
    }
}
