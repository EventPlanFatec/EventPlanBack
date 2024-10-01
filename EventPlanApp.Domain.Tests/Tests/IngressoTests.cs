using EventPlanApp.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Tests.Tests
{
    public class IngressoTests
    {
        
        [Fact]
        public void Ingresso_ValidarValor_MaiorQueZero()
        {
            var ingresso = new Ingresso { Valor = -1 };
            var validationResults = ValidateModel(ingresso);
            validationResults.Should().Contain(v => v.ErrorMessage == "O valor do ingresso deve ser maior que zero.");
        }

        [Fact]
        public void Ingresso_ValidarQRCode_Obrigatorio()
        {
            var ingresso = new Ingresso { QRCode = null };
            var validationResults = ValidateModel(ingresso);
            validationResults.Should().Contain(v => v.ErrorMessage == "O QR Code é obrigatório.");
        }

        [Fact]
        public void Ingresso_ValidarQRCode_MaxLength()
        {
            var ingresso = new Ingresso { QRCode = new string('A', 201) };
            var validationResults = ValidateModel(ingresso);
            validationResults.Should().Contain(v => v.ErrorMessage == "O QR Code não pode exceder 200 caracteres.");
        }

        [Fact]
        public void Ingresso_ValidarNomeEvento_Obrigatorio()
        {
            var ingresso = new Ingresso { NomeEvento = null };
            var validationResults = ValidateModel(ingresso);
            validationResults.Should().Contain(v => v.ErrorMessage == "O nome do evento é obrigatório.");
        }

        
        private List<ValidationResult> ValidateModel(Ingresso ingresso)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(ingresso, null, null);
            Validator.TryValidateObject(ingresso, validationContext, validationResults, true);
            return validationResults;
        }
    }

}
