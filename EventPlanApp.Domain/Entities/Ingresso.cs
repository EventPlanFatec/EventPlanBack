using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class Ingresso
    {
        public int IngressoId { get; set; }

        private decimal _valor;
        public decimal Valor
        {
            get => _valor;
            set
            {
                ValidateValor(value);
                _valor = value;
            }
        }

        private string _qrCode;
        public string QRCode
        {
            get => _qrCode;
            set
            {
                ValidateQRCode(value);
                _qrCode = value;
            }
        }

        private string _nomeEvento;
        public string NomeEvento
        {
            get => _nomeEvento;
            set
            {
                ValidateNomeEvento(value);
                _nomeEvento = value;
            }
        }

        private DateTime _data;
        public DateTime Data
        {
            get => _data;
            set
            {
                ValidateData(value);
                _data = value;
            }
        }

        public int UsuarioFinalId { get; set; }
        public virtual UsuarioFinal UsuarioFinal { get; set; }

        // Adicionando a propriedade Evento
        public int EventoId { get; set; } // ID do evento associado
        public virtual Evento Evento { get; set; } // Propriedade de navegação

        // Validações
        private void ValidateValor(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor deve ser maior que zero.");
            }
        }

        private void ValidateQRCode(string qrCode)
        {
            if (string.IsNullOrWhiteSpace(qrCode))
            {
                throw new ArgumentException("O QRCode é obrigatório.");
            }
        }

        private void ValidateNomeEvento(string nomeEvento)
        {
            if (string.IsNullOrWhiteSpace(nomeEvento))
            {
                throw new ArgumentException("O nome do evento é obrigatório.");
            }
        }

        private void ValidateData(DateTime data)
        {
            if (data < DateTime.Now)
            {
                throw new ArgumentException("A data não pode ser no passado.");
            }
        }
    }
}
