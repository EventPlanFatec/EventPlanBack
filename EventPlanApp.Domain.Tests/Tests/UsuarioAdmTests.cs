using System;
using Xunit;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Tests.Domain.Entities
{
    public class UsuarioAdmTests
    {
        [Fact]
        public void CriarUsuarioAdm_Valido_DeveFuncionar()
        {
            // Act
            var usuarioAdm = new UsuarioAdm("usuario@exemplo.com", "senha123", "Nome do Usuário", "1234567890");

            // Assert
            Assert.NotNull(usuarioAdm);
            Assert.Equal("usuario@exemplo.com", usuarioAdm.Email);
            Assert.Equal("senha123", usuarioAdm.Senha);
            Assert.Equal("Nome do Usuário", usuarioAdm.NomeUsuario);
            Assert.Equal("1234567890", usuarioAdm.Telefone);
        }

        [Theory]
        [InlineData("", "senha123", "Nome do Usuário", "1234567890")] // Email vazio
        [InlineData("usuario@exemplo.com", "", "Nome do Usuário", "1234567890")] // Senha vazia
        [InlineData("usuario@exemplo.com", "123", "Nome do Usuário", "1234567890")] // Senha muito curta
        [InlineData("usuario@exemplo.com", "senha123", "", "1234567890")] // Nome de usuário vazio
        [InlineData("usuario@exemplo.com", "senha123", "Nome do Usuário", "")] // Telefone vazio
        [InlineData("usuario@exemplo.com", "senha123", "Nome do Usuário", "123456")] // Telefone curto
        [InlineData("usuario@exemplo.com", "senha123", "Nome do Usuário", "1234567890123456")] // Telefone longo
        public void CriarUsuarioAdm_Invalido_NaoDeveFuncionar(string email, string senha, string nomeUsuario, string telefone)
        {
            // Assert
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                // Act
                new UsuarioAdm(email, senha, nomeUsuario, telefone);
            });

            Assert.NotNull(exception);
        }

        [Fact]
        public void CriarUsuarioAdm_EmailInvalido_NaoDeveFuncionar()
        {
            // Assert
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                // Act
                new UsuarioAdm("usuarioexemplo.com", "senha123", "Nome do Usuário", "1234567890");
            });

            Assert.Equal("O e-mail deve ser válido.", exception.Message);
        }
    }
}
