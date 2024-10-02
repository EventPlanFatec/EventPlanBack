using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class UsuarioFinal
    {
        public int Id { get; set; }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set
            {
                ValidateNome(value);
                _nome = value;
            }
        }

        private string _sobrenome;
        public string Sobrenome
        {
            get => _sobrenome;
            set
            {
                ValidateSobrenome(value);
                _sobrenome = value;
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

        private string _numeroCasa;
        public string NumeroCasa
        {
            get => _numeroCasa;
            set
            {
                ValidateNumeroCasa(value);
                _numeroCasa = value;
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

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                ValidateEmail(value);
                _email = value;
            }
        }

        private string _telefone;
        public string Telefone
        {
            get => _telefone;
            set
            {
                ValidateTelefone(value);
                _telefone = value;
            }
        }

        private string _ddd;
        public string DDD
        {
            get => _ddd;
            set
            {
                ValidateDDD(value);
                _ddd = value;
            }
        }

        private DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get => _dataNascimento;
            set
            {
                ValidateDataNascimento(value);
                _dataNascimento = value;
            }
        }

        private string _preferencias01;
        public string Preferencias01
        {
            get => _preferencias01;
            set
            {
                ValidatePreferencias(value);
                _preferencias01 = value;
            }
        }

        private string _preferencias02;
        public string Preferencias02
        {
            get => _preferencias02;
            set
            {
                ValidatePreferencias(value);
                _preferencias02 = value;
            }
        }

        private string _preferencias03;
        public string Preferencias03
        {
            get => _preferencias03;
            set
            {
                ValidatePreferencias(value);
                _preferencias03 = value;
            }
        }

        public ICollection<Ingresso> Ingressos { get; set; } = new List<Ingresso>();
        public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

        // Validações
        private void ValidateNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome não pode ser nulo ou vazio.");
            }
        }

        private void ValidateSobrenome(string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(sobrenome))
            {
                throw new ArgumentException("Sobrenome não pode ser nulo ou vazio.");
            }
        }

        private void ValidateTipoLogradouro(string tipoLogradouro)
        {
            if (string.IsNullOrWhiteSpace(tipoLogradouro))
            {
                throw new ArgumentException("Tipo de logradouro não pode ser nulo ou vazio.");
            }
        }

        private void ValidateLogradouro(string logradouro)
        {
            if (string.IsNullOrWhiteSpace(logradouro))
            {
                throw new ArgumentException("Logradouro não pode ser nulo ou vazio.");
            }
        }

        private void ValidateNumeroCasa(string numeroCasa)
        {
            if (string.IsNullOrWhiteSpace(numeroCasa))
            {
                throw new ArgumentException("Número da casa não pode ser nulo ou vazio.");
            }
        }

        private void ValidateBairro(string bairro)
        {
            if (string.IsNullOrWhiteSpace(bairro))
            {
                throw new ArgumentException("Bairro não pode ser nulo ou vazio.");
            }
        }

        private void ValidateCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade))
            {
                throw new ArgumentException("Cidade não pode ser nula ou vazia.");
            }
        }

        private void ValidateEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
            {
                throw new ArgumentException("Estado não pode ser nulo ou vazio.");
            }

            if (estado.Length != 2)
            {
                throw new ArgumentException("Estado deve ter exatamente 2 caracteres.");
            }
        }

        private void ValidateCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                throw new ArgumentException("CEP não pode ser nulo ou vazio.");
            }

            // Exemplo de validação simples de CEP, supondo que seja um formato de 8 dígitos
            if (!Regex.IsMatch(cep, @"^\d{5}-?\d{3}$"))
            {
                throw new ArgumentException("CEP deve ser um formato válido (XXXXX-XXX).");
            }
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email não pode ser nulo ou vazio.");
            }

            // Validação simples de email
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new ArgumentException("Email deve ser um formato válido.");
            }
        }

        private void ValidateTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                throw new ArgumentException("Telefone não pode ser nulo ou vazio.");
            }
        }

        private void ValidateDDD(string ddd)
        {
            if (string.IsNullOrWhiteSpace(ddd))
            {
                throw new ArgumentException("DDD não pode ser nulo ou vazio.");
            }

            // Exemplo: validação de DDD com 2 dígitos
            if (ddd.Length != 2)
            {
                throw new ArgumentException("DDD deve ter exatamente 2 caracteres.");
            }
        }

        private void ValidateDataNascimento(DateTime dataNascimento)
        {
            if (dataNascimento >= DateTime.Now)
            {
                throw new ArgumentException("Data de nascimento não pode ser uma data futura.");
            }
        }

        private void ValidatePreferencias(string preferencias)
        {
            if (!string.IsNullOrWhiteSpace(preferencias) && preferencias.Length > 100)
            {
                throw new ArgumentException("As preferências não podem exceder 100 caracteres.");
            }
        }
    }


}
