using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Tests.Tests
{
    public class OrganizacaoTests
    {
        [Fact]
        public void Organizacao_ValidarCNPJ_Obrigatorio()
        {
            var organizacao = new Organizacao { CNPJ = null };
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O CNPJ é obrigatório.");
        }

        [Fact]
        public void Organizacao_ValidarCNPJ_FormatoInvalido()
        {
            var organizacao = new Organizacao { CNPJ = "12345678000195" }; // Formato inválido
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O CNPJ deve estar no formato 00.000.000/0000-00.");
        }

        [Fact]
        public void Organizacao_ValidarTipoLogradouro_Obrigatorio()
        {
            var organizacao = new Organizacao { TipoLogradouro = null };
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O tipo de logradouro é obrigatório.");
        }

        [Fact]
        public void Organizacao_ValidarTipoLogradouro_TamanhoMaximo()
        {
            var organizacao = new Organizacao { TipoLogradouro = new string('A', 51) }; // Mais de 50 caracteres
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O tipo de logradouro não pode exceder 50 caracteres.");
        }

        [Fact]
        public void Organizacao_ValidarLogradouro_Obrigatorio()
        {
            var organizacao = new Organizacao { Logradouro = null };
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O logradouro é obrigatório.");
        }

        [Fact]
        public void Organizacao_ValidarLogradouro_TamanhoMaximo()
        {
            var organizacao = new Organizacao { Logradouro = new string('A', 151) }; // Mais de 150 caracteres
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O logradouro não pode exceder 150 caracteres.");
        }

        [Fact]
        public void Organizacao_ValidarNumeroPredio_Obrigatorio()
        {
            var organizacao = new Organizacao { NumeroPredio = null };
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O número do prédio é obrigatório.");
        }

        [Fact]
        public void Organizacao_ValidarNumeroPredio_TamanhoMaximo()
        {
            var organizacao = new Organizacao { NumeroPredio = new string('A', 11) }; // Mais de 10 caracteres
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O número do prédio não pode exceder 10 caracteres.");
        }

        [Fact]
        public void Organizacao_ValidarBairro_Obrigatorio()
        {
            var organizacao = new Organizacao { Bairro = null };
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O bairro é obrigatório.");
        }

        [Fact]
        public void Organizacao_ValidarBairro_TamanhoMaximo()
        {
            var organizacao = new Organizacao { Bairro = new string('A', 101) }; // Mais de 100 caracteres
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O bairro não pode exceder 100 caracteres.");
        }

        [Fact]
        public void Organizacao_ValidarCidade_Obrigatoria()
        {
            var organizacao = new Organizacao { Cidade = null };
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A cidade é obrigatória.");
        }

        [Fact]
        public void Organizacao_ValidarCidade_TamanhoMaximo()
        {
            var organizacao = new Organizacao { Cidade = new string('A', 101) }; // Mais de 100 caracteres
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A cidade não pode exceder 100 caracteres.");
        }

        [Fact]
        public void Organizacao_ValidarEstado_Obrigatorio()
        {
            var organizacao = new Organizacao { Estado = null };
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O estado é obrigatório.");
        }

        [Fact]
        public void Organizacao_ValidarEstado_TamanhoInvalido()
        {
            var organizacao = new Organizacao { Estado = "ABC" }; // Mais de 2 caracteres
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O estado deve conter 2 caracteres.");
        }

        [Fact]
        public void Organizacao_ValidarCEP_Obrigatorio()
        {
            var organizacao = new Organizacao { CEP = null };
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O CEP é obrigatório.");
        }

        [Fact]
        public void Organizacao_ValidarCEP_FormatoInvalido()
        {
            var organizacao = new Organizacao { CEP = "12345678" }; // Formato inválido
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O CEP deve estar no formato 00000-000.");
        }

        [Fact]
        public void Organizacao_ValidarNotaMedia_ValorValido()
        {
            var organizacao = new Organizacao { NotaMedia = 6 }; // Fora do intervalo
            var validationResults = ValidateModel(organizacao);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A nota média deve estar entre 0 e 5.");
        }

        private List<ValidationResult> ValidateModel(Organizacao organizacao)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(organizacao, null, null);
            Validator.TryValidateObject(organizacao, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
