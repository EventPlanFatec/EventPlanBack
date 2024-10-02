using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Validation;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Tests
{
    public class OrganizacaoTests
    {
        private readonly OrganizacaoValidator _validator;

        public OrganizacaoTests()
        {
            _validator = new OrganizacaoValidator();
        }

        [Fact]
        public void CNPJ_Invalido_Should_Have_Error()
        {
            var organizacao = new Organizacao();

            var exception = Assert.Throws<ArgumentException>(() => organizacao.CNPJ = "123");
            Assert.Equal("O CNPJ deve ter 14 caracteres.", exception.Message);
        }

        [Fact]
        public void TipoLogradouro_Nulo_Should_Have_Error()
        {
            var organizacao = new Organizacao();

            var exception = Assert.Throws<ArgumentException>(() => organizacao.TipoLogradouro = null);
            Assert.Equal("O tipo de logradouro é obrigatório.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => organizacao.TipoLogradouro = string.Empty);
            Assert.Equal("O tipo de logradouro é obrigatório.", exception.Message);
        }

        [Fact]
        public void Logradouro_Nulo_Should_Have_Error()
        {
            var organizacao = new Organizacao();

            var exception = Assert.Throws<ArgumentException>(() => organizacao.Logradouro = null);
            Assert.Equal("O logradouro é obrigatório.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => organizacao.Logradouro = string.Empty);
            Assert.Equal("O logradouro é obrigatório.", exception.Message);
        }

        [Fact]
        public void NumeroPredio_Nulo_Should_Have_Error()
        {
            var organizacao = new Organizacao();

            var exception = Assert.Throws<ArgumentException>(() => organizacao.NumeroPredio = null);
            Assert.Equal("O número do prédio é obrigatório.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => organizacao.NumeroPredio = string.Empty);
            Assert.Equal("O número do prédio é obrigatório.", exception.Message);
        }

        [Fact]
        public void Bairro_Nulo_Should_Have_Error()
        {
            var organizacao = new Organizacao();

            var exception = Assert.Throws<ArgumentException>(() => organizacao.Bairro = null);
            Assert.Equal("O bairro é obrigatório.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => organizacao.Bairro = string.Empty);
            Assert.Equal("O bairro é obrigatório.", exception.Message);
        }

        [Fact]
        public void Cidade_Nulo_Should_Have_Error()
        {
            var organizacao = new Organizacao();

            var exception = Assert.Throws<ArgumentException>(() => organizacao.Cidade = null);
            Assert.Equal("A cidade é obrigatória.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => organizacao.Cidade = string.Empty);
            Assert.Equal("A cidade é obrigatória.", exception.Message);
        }

        [Fact]
        public void Estado_Invalido_Should_Have_Error()
        {
            var organizacao = new Organizacao();

            var exception = Assert.Throws<ArgumentException>(() => organizacao.Estado = "ABC");
            Assert.Equal("O estado deve ter 2 caracteres.", exception.Message);
        }

        [Fact]
        public void CEP_Nulo_Should_Have_Error()
        {
            var organizacao = new Organizacao();

            var exception = Assert.Throws<ArgumentException>(() => organizacao.CEP = null);
            Assert.Equal("O CEP é obrigatório.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => organizacao.CEP = string.Empty);
            Assert.Equal("O CEP é obrigatório.", exception.Message);
        }

        [Fact]
        public void NotaMedia_Invalida_Should_Have_Error()
        {
            var organizacao = new Organizacao();

            var exception = Assert.Throws<ArgumentException>(() => organizacao.NotaMedia = 11);
            Assert.Equal("A nota média deve estar entre 0 e 10.", exception.Message);
        }

        [Fact]
        public void Organizacao_Valida_Should_Not_Have_Errors()
        {
            var organizacao = new Organizacao
            {
                CNPJ = "12345678000195", // CNPJ válido
                TipoLogradouro = "Rua",
                Logradouro = "Testes",
                NumeroPredio = "123",
                Bairro = "Centro",
                Cidade = "Cidade Exemplo",
                Estado = "SP",
                CEP = "12345678",
                NotaMedia = 8, // Nota média válida
                UsuarioAdmId = 1 // ID de administrador válido
            };

            var validationResult = _validator.TestValidate(organizacao);
            validationResult.ShouldNotHaveAnyValidationErrors();
        }
    }
}
