using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class Organizacao
    {
        public int OrganizacaoId { get; set; }

        private string _cnpj;
        public string CNPJ
        {
            get => _cnpj;
            set
            {
                ValidateCNPJ(value);
                _cnpj = value;
            }
        }

        private string _tipoLogradouro;
        public string TipoLogradouro
        {
            get => _tipoLogradouro;
            set
            {
                ValidateTipoLogradouro(value);
                _tipoLogradouro = value;
            }
        }

        private string _logradouro;
        public string Logradouro
        {
            get => _logradouro;
            set
            {
                ValidateLogradouro(value);
                _logradouro = value;
            }
        }

        private string _numeroPredio;
        public string NumeroPredio
        {
            get => _numeroPredio;
            set
            {
                ValidateNumeroPredio(value);
                _numeroPredio = value;
            }
        }

        private string _bairro;
        public string Bairro
        {
            get => _bairro;
            set
            {
                ValidateBairro(value);
                _bairro = value;
            }
        }

        private string _cidade;
        public string Cidade
        {
            get => _cidade;
            set
            {
                ValidateCidade(value);
                _cidade = value;
            }
        }

        private string _estado;
        public string Estado
        {
            get => _estado;
            set
            {
                ValidateEstado(value);
                _estado = value;
            }
        }

        private string _cep;
        public string CEP
        {
            get => _cep;
            set
            {
                ValidateCEP(value);
                _cep = value;
            }
        }

        private decimal _notaMedia;
        public decimal NotaMedia
        {
            get => _notaMedia;
            set
            {
                ValidateNotaMedia(value);
                _notaMedia = value;
            }
        }

        public int UsuarioAdmId { get; set; }
        public virtual ICollection<UsuarioAdm> UsuariosAdm { get; set; } = new List<UsuarioAdm>();
        public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

        // Validações
        private void ValidateCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                throw new ArgumentException("O CNPJ é obrigatório.");
            }
            if (cnpj.Length != 14)
            {
                throw new ArgumentException("O CNPJ deve ter 14 caracteres.");
            }
        }

        private void ValidateTipoLogradouro(string tipoLogradouro)
        {
            if (string.IsNullOrWhiteSpace(tipoLogradouro))
            {
                throw new ArgumentException("O tipo de logradouro é obrigatório.");
            }
        }

        private void ValidateLogradouro(string logradouro)
        {
            if (string.IsNullOrWhiteSpace(logradouro))
            {
                throw new ArgumentException("O logradouro é obrigatório.");
            }
        }

        private void ValidateNumeroPredio(string numeroPredio)
        {
            if (string.IsNullOrWhiteSpace(numeroPredio))
            {
                throw new ArgumentException("O número do prédio é obrigatório.");
            }
        }

        private void ValidateBairro(string bairro)
        {
            if (string.IsNullOrWhiteSpace(bairro))
            {
                throw new ArgumentException("O bairro é obrigatório.");
            }
        }

        private void ValidateCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade))
            {
                throw new ArgumentException("A cidade é obrigatória.");
            }
        }

        private void ValidateEstado(string estado)
        {
            if (estado.Length != 2)
            {
                throw new ArgumentException("O estado deve ter 2 caracteres.");
            }
        }

        private void ValidateCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                throw new ArgumentException("O CEP é obrigatório.");
            }
            if (cep.Length != 8)
            {
                throw new ArgumentException("O CEP deve ter 8 caracteres.");
            }
        }

        private void ValidateNotaMedia(decimal notaMedia)
        {
            if (notaMedia < 0 || notaMedia > 10)
            {
                throw new ArgumentException("A nota média deve estar entre 0 e 10.");
            }
        }
    }
}
