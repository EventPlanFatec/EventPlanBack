using System;
using Xunit;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Tests.Domain.Entities
{
    public class UsuarioFinalTests
    {
        [Fact]
        public void CriarUsuarioFinal_Valido_DeveFuncionar()
        {
            // Arrange
            var endereco = new Endereco("Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", "00000-000");
            var dataNascimento = new DateTime(2000, 1, 1);

            // Act
            var usuarioFinal = new UsuarioFinal("Nome Teste", "Sobrenome Teste", endereco, "usuario@exemplo.com",
                                                 "1234567890", "11", dataNascimento);

            // Assert
            Assert.NotNull(usuarioFinal);
            Assert.NotEqual(Guid.Empty, usuarioFinal.Id);
            Assert.Equal("Nome Teste", usuarioFinal.Nome);
            Assert.Equal("Sobrenome Teste", usuarioFinal.Sobrenome);
            Assert.Equal("usuario@exemplo.com", usuarioFinal.Email);
            Assert.Equal("1234567890", usuarioFinal.Telefone);
            Assert.Equal("11", usuarioFinal.DDD);
            Assert.Equal(dataNascimento, usuarioFinal.DataNascimento);
        }

        [Theory]
        [InlineData(null, "Sobrenome", "Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", "00000-000", "usuario@exemplo.com", "1234567890", "11", "2000-01-01")]
        [InlineData("Nome", null, "Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", "00000-000", "usuario@exemplo.com", "1234567890", "11", "2000-01-01")]
        [InlineData("Nome", "Sobrenome", null, "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", "00000-000", "usuario@exemplo.com", "1234567890", "11", "2000-01-01")]
        [InlineData("Nome", "Sobrenome", "Rua", null, "123", "Bairro Teste", "Cidade Teste", "SP", "00000-000", "usuario@exemplo.com", "1234567890", "11", "2000-01-01")]
        [InlineData("Nome", "Sobrenome", "Rua", "Teste", null, "Bairro Teste", "Cidade Teste", "SP", "00000-000", "usuario@exemplo.com", "1234567890", "11", "2000-01-01")]
        [InlineData("Nome", "Sobrenome", "Rua", "Teste", "123", null, "Cidade Teste", "SP", "00000-000", "usuario@exemplo.com", "1234567890", "11", "2000-01-01")]
        [InlineData("Nome", "Sobrenome", "Rua", "Teste", "123", "Bairro Teste", null, "SP", "00000-000", "usuario@exemplo.com", "1234567890", "11", "2000-01-01")]
        [InlineData("Nome", "Sobrenome", "Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", null, "00000-000", "usuario@exemplo.com", "1234567890", "11", "2000-01-01")]
        [InlineData("Nome", "Sobrenome", "Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", null, "usuario@exemplo.com", "1234567890", "11", "2000-01-01")]
        public void CriarUsuarioFinal_Invalido_NaoDeveFuncionar(string nome, string sobrenome, string tipoLogradouro, string logradouro,
            string numeroCasa, string bairro, string cidade, string estado, string cep,
            string email, string telefone, string ddd, string dataNascimentoStr)
        {
            // Arrange
            DateTime dataNascimento = DateTime.Parse(dataNascimentoStr);
            Endereco endereco = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Criar um endereço válido apenas se todos os parâmetros forem válidos
                if (!string.IsNullOrEmpty(tipoLogradouro) && !string.IsNullOrEmpty(logradouro) &&
                    !string.IsNullOrEmpty(numeroCasa) && !string.IsNullOrEmpty(bairro) &&
                    !string.IsNullOrEmpty(cidade) && !string.IsNullOrEmpty(estado) &&
                    !string.IsNullOrEmpty(cep))
                {
                    endereco = new Endereco(tipoLogradouro, logradouro, numeroCasa, bairro, cidade, estado, cep);
                }

                var usuarioFinal = new UsuarioFinal(nome, sobrenome, endereco, email, telefone, ddd, dataNascimento);
            });
        }

        [Fact]
        public void CriarUsuarioFinal_DataNascimentoFutura_NaoDeveFuncionar()
        {
            // Arrange
            var endereco = new Endereco("Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", "00000-000");
            var dataNascimentoFutura = DateTime.Now.AddYears(1);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var usuarioFinal = new UsuarioFinal("Nome Teste", "Sobrenome Teste", endereco, "usuario@exemplo.com",
                                                     "1234567890", "11", dataNascimentoFutura);
            });
        }

        [Fact]
        public void CriarUsuarioFinal_EmailInvalido_NaoDeveFuncionar()
        {
            // Arrange
            var endereco = new Endereco("Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", "00000-000");
            var dataNascimento = new DateTime(2000, 1, 1);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var usuarioFinal = new UsuarioFinal("Nome Teste", "Sobrenome Teste", endereco, "email-invalido",
                                                     "1234567890", "11", dataNascimento);
            });
        }
    }
}
