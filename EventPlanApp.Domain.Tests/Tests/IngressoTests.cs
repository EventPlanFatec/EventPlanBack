using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Validation;
using FluentAssertions;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Tests
{
    public class IngressoTests
    {
        private readonly IngressoValidator _validator;

        public IngressoTests()
        {
            _validator = new IngressoValidator();
        }

        [Fact]
        public void Valor_Negativo_Should_Have_Error()
        {
            var ingresso = new Ingresso();

            var exception = Assert.Throws<ArgumentException>(() => ingresso.Valor = -1);
            Assert.Equal("O valor deve ser maior que zero.", exception.Message);
        }

        [Fact]
        public void Valor_Zero_Should_Have_Error()
        {
            var ingresso = new Ingresso();

            var exception = Assert.Throws<ArgumentException>(() => ingresso.Valor = 0);
            Assert.Equal("O valor deve ser maior que zero.", exception.Message);
        }

        [Fact]
        public void QRCode_Nulo_Should_Have_Error()
        {
            var ingresso = new Ingresso();

            var exception = Assert.Throws<ArgumentException>(() => ingresso.QRCode = null);
            Assert.Equal("O QRCode é obrigatório.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => ingresso.QRCode = string.Empty);
            Assert.Equal("O QRCode é obrigatório.", exception.Message);
        }

        [Fact]
        public void NomeEvento_Nulo_Should_Have_Error()
        {
            var ingresso = new Ingresso();

            var exception = Assert.Throws<ArgumentException>(() => ingresso.NomeEvento = null);
            Assert.Equal("O nome do evento é obrigatório.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => ingresso.NomeEvento = string.Empty);
            Assert.Equal("O nome do evento é obrigatório.", exception.Message);
        }

        [Fact]
        public void Data_Passada_Should_Have_Error()
        {
            var ingresso = new Ingresso();

            var exception = Assert.Throws<ArgumentException>(() => ingresso.Data = DateTime.Now.AddDays(-1));
            Assert.Equal("A data não pode ser no passado.", exception.Message);
        }

        [Fact]
        public void Ingresso_Valido_Should_Not_Have_Errors()
        {
            var ingresso = new Ingresso
            {
                Valor = 100,
                QRCode = "1234567890",
                NomeEvento = "Evento Teste",
                Data = DateTime.Now.AddDays(1), // Data no futuro
                UsuarioFinalId = 1 // ID de usuário válido
            };

            var validationResult = _validator.TestValidate(ingresso);
            validationResult.ShouldNotHaveAnyValidationErrors();
        }
    }
}
