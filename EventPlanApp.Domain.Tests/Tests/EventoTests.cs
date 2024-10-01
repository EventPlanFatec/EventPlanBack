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
    public class EventoTests
    {
        [Fact]
        public void Evento_ValidarNomeEvento_Obrigatorio()
        {
            var evento = new Evento { NomeEvento = null };
            var validationResults = ValidateModel(evento);
            validationResults.Should().Contain(v => v.ErrorMessage == "O nome do evento é obrigatório.");
        }

                               
        [Fact]
        public void Evento_ValidarTipoLogradouro_Obrigatorio()
        {
            var evento = new Evento { TipoLogradouro = null };
            var validationResults = ValidateModel(evento);
            validationResults.Should().Contain(v => v.ErrorMessage == "O tipo de logradouro é obrigatório.");
        }

        [Fact]
        public void Evento_ValidarLogradouro_Obrigatorio()
        {
            var evento = new Evento { Logradouro = null };
            var validationResults = ValidateModel(evento);
            validationResults.Should().Contain(v => v.ErrorMessage == "O logradouro é obrigatório.");
        }

        [Fact]
        public void Evento_ValidarNumeroCasa_Obrigatorio()
        {
            var evento = new Evento { NumeroCasa = null };
            var validationResults = ValidateModel(evento);
            validationResults.Should().Contain(v => v.ErrorMessage == "O número da casa é obrigatório.");
        }

        [Fact]
        public void Evento_ValidarBairro_Obrigatorio()
        {
            var evento = new Evento { Bairro = null };
            var validationResults = ValidateModel(evento);
            validationResults.Should().Contain(v => v.ErrorMessage == "O bairro é obrigatório.");
        }

        [Fact]
        public void Evento_ValidarCidade_Obrigatorio()
        {
            var evento = new Evento { Cidade = null };
            var validationResults = ValidateModel(evento);
            validationResults.Should().Contain(v => v.ErrorMessage == "A cidade é obrigatória.");
        }

        [Fact]
        public void Evento_ValidarEstado_Obrigatorio()
        {
            var evento = new Evento { Estado = null };
            var validationResults = ValidateModel(evento);
            validationResults.Should().Contain(v => v.ErrorMessage == "O estado é obrigatório.");
        }

        [Fact]
        public void Evento_ValidarCEP_Obrigatorio()
        {
            var evento = new Evento { CEP = null };
            var validationResults = ValidateModel(evento);
            validationResults.Should().Contain(v => v.ErrorMessage == "O CEP é obrigatório.");
        }

                

        private List<ValidationResult> ValidateModel(Evento evento)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(evento, null, null);
            Validator.TryValidateObject(evento, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
