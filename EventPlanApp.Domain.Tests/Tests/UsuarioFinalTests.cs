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
    public class UsuarioFinalTests
    {
        private readonly UsuarioFinalValidator _validator;

        public UsuarioFinalTests()
        {
            _validator = new UsuarioFinalValidator();
        }

        [Fact]
        public void Nome_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Nome = "");
            Assert.Equal("Nome não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Nome = null);
            Assert.Equal("Nome não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void Sobrenome_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Sobrenome = "");
            Assert.Equal("Sobrenome não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Sobrenome = null);
            Assert.Equal("Sobrenome não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void TipoLogradouro_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.TipoLogradouro = "");
            Assert.Equal("Tipo de logradouro não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.TipoLogradouro = null);
            Assert.Equal("Tipo de logradouro não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void Logradouro_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Logradouro = "");
            Assert.Equal("Logradouro não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Logradouro = null);
            Assert.Equal("Logradouro não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void NumeroCasa_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.NumeroCasa = "");
            Assert.Equal("Número da casa não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.NumeroCasa = null);
            Assert.Equal("Número da casa não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void Bairro_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Bairro = "");
            Assert.Equal("Bairro não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Bairro = null);
            Assert.Equal("Bairro não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void Cidade_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Cidade = "");
            Assert.Equal("Cidade não pode ser nula ou vazia.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Cidade = null);
            Assert.Equal("Cidade não pode ser nula ou vazia.", exception.Message);
        }

        [Fact]
        public void Estado_Invalid_Should_Have_Error()
        {
            // Arrange
            var usuario = new UsuarioFinal();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => usuario.Estado = "SPBR"); // Estado inválido
            Assert.Equal("Estado deve ter exatamente 2 caracteres.", exception.Message);
        }

        [Fact]
        public void CEP_Invalid_Should_Have_Error()
        {
            // Arrange
            var usuario = new UsuarioFinal();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => usuario.CEP = "123456");
            Assert.Equal("CEP deve ser um formato válido (XXXXX-XXX).", exception.Message);
        }

        [Fact]
        public void Email_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Email = "");
            Assert.Equal("Email não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Email = null);
            Assert.Equal("Email não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Email = "email.invalido");
            Assert.Equal("Email deve ser um formato válido.", exception.Message);
        }

        [Fact]
        public void Telefone_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Telefone = "");
            Assert.Equal("Telefone não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Telefone = null);
            Assert.Equal("Telefone não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void DDD_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.DDD = "");
            Assert.Equal("DDD não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.DDD = null);
            Assert.Equal("DDD não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.DDD = "1");
            Assert.Equal("DDD deve ter exatamente 2 caracteres.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.DDD = "123");
            Assert.Equal("DDD deve ter exatamente 2 caracteres.", exception.Message);
        }

        [Fact]
        public void DataNascimento_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.DataNascimento = DateTime.Now.AddDays(1));
            Assert.Equal("Data de nascimento não pode ser uma data futura.", exception.Message);
        }

        [Fact]
        public void Preferencias_Invalid_Should_Have_Error()
        {
            var usuarioFinal = new UsuarioFinal();

            var exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Preferencias01 = new string('A', 101));
            Assert.Equal("As preferências não podem exceder 100 caracteres.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Preferencias02 = new string('A', 101));
            Assert.Equal("As preferências não podem exceder 100 caracteres.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioFinal.Preferencias03 = new string('A', 101));
            Assert.Equal("As preferências não podem exceder 100 caracteres.", exception.Message);
        }

        [Fact]
        public void UsuarioFinal_Valido_Should_Not_Have_Errors()
        {
            var usuarioFinal = new UsuarioFinal
            {
                Nome = "João",
                Sobrenome = "Silva",
                TipoLogradouro = "Rua",
                Logradouro = "Avenida Brasil",
                NumeroCasa = "123",
                Bairro = "Centro",
                Cidade = "São Paulo",
                Estado = "SP",
                CEP = "12345-678",
                Email = "joao.silva@exemplo.com",
                Telefone = "11987654321",
                DDD = "11",
                DataNascimento = new DateTime(2000, 1, 1),
                Preferencias01 = "Música",
                Preferencias02 = "Esportes",
                Preferencias03 = "Viagens"
            };

            var validationResult = _validator.TestValidate(usuarioFinal);
            validationResult.ShouldNotHaveAnyValidationErrors();
        }
    }
}
