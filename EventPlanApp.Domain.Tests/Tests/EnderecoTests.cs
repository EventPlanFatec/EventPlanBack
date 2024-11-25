using System;
using Xunit;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Tests.Domain.Entities
{
    public class EnderecoTests
    {
        [Fact]
        public void CriarEndereco_Valido_DeveFuncionar()
        {
            // Arrange
            var tipoLogradouro = "Rua";
            var logradouro = "Teste";
            var numeroCasa = "123";
            var bairro = "Bairro Teste";
            var cidade = "Cidade Teste";
            var estado = "SP";
            var cep = "00000-000";

            // Act
            var endereco = new Endereco(tipoLogradouro, logradouro, numeroCasa, bairro, cidade, estado, cep);

            // Assert
            Assert.NotNull(endereco);
            Assert.Equal(tipoLogradouro, endereco.TipoLogradouro);
            Assert.Equal(logradouro, endereco.Logradouro);
            Assert.Equal(numeroCasa, endereco.NumeroCasa);
            Assert.Equal(bairro, endereco.Bairro);
            Assert.Equal(cidade, endereco.Cidade);
            Assert.Equal(estado, endereco.Estado);
            Assert.Equal(cep, endereco.CEP);
        }

        [Theory]
        [InlineData(null, "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", "00000-000")]
        [InlineData("Rua", "Teste", null, "Bairro Teste", "Cidade Teste", "SP", "00000-000")]
        [InlineData("Rua", "Teste", "123", null, "Cidade Teste", "SP", "00000-000")]
        [InlineData("Rua", "Teste", "123", "Bairro Teste", null, "SP", "00000-000")]
        [InlineData("Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", null, "00000-000")]
        [InlineData("Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", null)]
        [InlineData("Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", "0000-000")]
        [InlineData("Rua", "Teste", "123", "Bairro Teste", "Cidade Teste", "SP", "000000000")]
        public void CriarEndereco_Invalido_NaoDeveFuncionar(string tipoLogradouro, string logradouro, string numeroCasa,
            string bairro, string cidade, string estado, string cep)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var endereco = new Endereco(tipoLogradouro, logradouro, numeroCasa, bairro, cidade, estado, cep);
            });
        }
    }
}
