using System;
using System.Text.RegularExpressions;

namespace EventPlanApp.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string TipoLogradouro { get; private set; }
        public string? Logradouro { get; private set; }
        public string NumeroCasa { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }

        public Endereco() { }

        public Endereco(string tipoLogradouro, string logradouro, string numeroCasa,
                        string bairro, string cidade, string estado, string cep)
        {
            ValidateDomain(tipoLogradouro, logradouro, numeroCasa, bairro, cidade, estado, cep);
            TipoLogradouro = tipoLogradouro;
            Logradouro = logradouro;
            NumeroCasa = numeroCasa;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }

        private void ValidateDomain(string tipoLogradouro, string logradouro, string numeroCasa,
                                    string bairro, string cidade, string estado, string cep)
        {
            if (string.IsNullOrWhiteSpace(tipoLogradouro))
                throw new ArgumentException("Tipo de logradouro não pode ser nulo ou vazio.");
            if (string.IsNullOrWhiteSpace(numeroCasa))
                throw new ArgumentException("Número da casa não pode ser nulo ou vazio.");
            if (string.IsNullOrWhiteSpace(bairro))
                throw new ArgumentException("Bairro não pode ser nulo ou vazio.");
            if (string.IsNullOrWhiteSpace(cidade))
                throw new ArgumentException("Cidade não pode ser nula ou vazia.");
            if (string.IsNullOrWhiteSpace(estado) || estado.Length != 2)
                throw new ArgumentException("Estado inválido. Deve ter exatamente 2 caracteres.");
            if (string.IsNullOrWhiteSpace(cep) || !Regex.IsMatch(cep, @"^\d{5}-?\d{3}$"))
                throw new ArgumentException("CEP deve ser um formato válido (XXXXX-XXX).");
        }
        public void AtualizarEndereco(string tipoLogradouro, string logradouro, string numeroCasa,
                                      string bairro, string cidade, string estado, string cep)
        {
            ValidateDomain(tipoLogradouro, logradouro, numeroCasa, bairro, cidade, estado, cep);

            TipoLogradouro = tipoLogradouro;
            Logradouro = logradouro;
            NumeroCasa = numeroCasa;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }
    }
}
