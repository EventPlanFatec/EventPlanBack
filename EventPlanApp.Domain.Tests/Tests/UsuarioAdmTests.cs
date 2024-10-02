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
    public class UsuarioAdmTests
    {
        private readonly UsuarioAdmValidator _validator;

        public UsuarioAdmTests()
        {
            _validator = new UsuarioAdmValidator();
        }

        [Fact]
        public void Email_Nulo_Should_Have_Error()
        {
            var usuarioAdm = new UsuarioAdm();

            var exception = Assert.Throws<ArgumentException>(() => usuarioAdm.Email = null);
            Assert.Equal("O e-mail é obrigatório.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioAdm.Email = string.Empty);
            Assert.Equal("O e-mail é obrigatório.", exception.Message);
        }

        [Fact]
        public void Email_Invalid_Should_Have_Error()
        {
            var usuarioAdm = new UsuarioAdm();

            var exception = Assert.Throws<ArgumentException>(() => usuarioAdm.Email = "invalidemail");
            Assert.Equal("O e-mail deve ser válido.", exception.Message);
        }

        [Fact]
        public void Senha_Nula_Should_Have_Error()
        {
            var usuarioAdm = new UsuarioAdm();

            var exception = Assert.Throws<ArgumentException>(() => usuarioAdm.Senha = null);
            Assert.Equal("A senha é obrigatória.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioAdm.Senha = string.Empty);
            Assert.Equal("A senha é obrigatória.", exception.Message);
        }

        [Fact]
        public void Senha_Too_Short_Should_Have_Error()
        {
            var usuarioAdm = new UsuarioAdm();

            var exception = Assert.Throws<ArgumentException>(() => usuarioAdm.Senha = "12345");
            Assert.Equal("A senha deve ter pelo menos 6 caracteres.", exception.Message);
        }

        [Fact]
        public void NomeUsuario_Nulo_Should_Have_Error()
        {
            var usuarioAdm = new UsuarioAdm();

            var exception = Assert.Throws<ArgumentException>(() => usuarioAdm.NomeUsuario = null);
            Assert.Equal("O nome de usuário é obrigatório.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioAdm.NomeUsuario = string.Empty);
            Assert.Equal("O nome de usuário é obrigatório.", exception.Message);
        }

        [Fact]
        public void Telefone_Nulo_Should_Have_Error()
        {
            var usuarioAdm = new UsuarioAdm();

            var exception = Assert.Throws<ArgumentException>(() => usuarioAdm.Telefone = null);
            Assert.Equal("O telefone é obrigatório.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioAdm.Telefone = string.Empty);
            Assert.Equal("O telefone é obrigatório.", exception.Message);
        }

        [Fact]
        public void Telefone_Invalid_Length_Should_Have_Error()
        {
            var usuarioAdm = new UsuarioAdm();

            var exception = Assert.Throws<ArgumentException>(() => usuarioAdm.Telefone = "123456");
            Assert.Equal("O telefone deve ter entre 10 e 15 caracteres.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => usuarioAdm.Telefone = "1234567890123456");
            Assert.Equal("O telefone deve ter entre 10 e 15 caracteres.", exception.Message);
        }

        [Fact]
        public void UsuarioAdm_Valido_Should_Not_Have_Errors()
        {
            var usuarioAdm = new UsuarioAdm
            {
                Email = "usuario@exemplo.com",
                Senha = "senha123",
                NomeUsuario = "UsuarioTeste",
                Telefone = "1234567890"
            };

            var validationResult = _validator.TestValidate(usuarioAdm);
            validationResult.ShouldNotHaveAnyValidationErrors();
        }
    }
}
