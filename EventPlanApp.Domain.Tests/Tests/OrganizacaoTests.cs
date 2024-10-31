using EventPlanApp.Domain.Entities;
using Xunit;

namespace EventPlanApp.Tests.Domain.Entities
{
    public class OrganizacaoTests
    {
        [Fact]
        public void CriarOrganizacao_Valido_DeveFuncionar()
        {
            // Arrange
            var endereco = new Endereco("Rua", "Logradouro Teste", "123", "Centro", "Cidade Teste", "SP", "00000000");
            var status = "Aprovado";
            // Act
            var organizacao = new Organizacao("12345678000195", endereco, 8.5m, status);

            // Assert
            Assert.NotNull(organizacao);
            Assert.Equal("12345678000195", organizacao.CNPJ);
            Assert.Equal(endereco, organizacao.Endereco);
            Assert.Equal(status, organizacao.Status);
        }

        [Fact]
        public void CriarOrganizacao_CNPJInvalido_DeveLancarExcecao()
        {
            // Arrange
            var endereco = new Endereco("Rua", "Logradouro Teste", "123", "Centro", "Cidade Teste", "SP", "00000000");
            var status = "Aprovado";
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Organizacao("", endereco, 8.5m, status));
            Assert.Equal("O CNPJ deve ter 14 caracteres e é obrigatório.", ex.Message);
        }

        [Fact]
        public void CriarOrganizacao_NotaMediaInvalida_DeveLancarExcecao()
        {
            // Arrange
            var endereco = new Endereco("Rua", "Logradouro Teste", "123", "Centro", "Cidade Teste", "SP", "00000000");
            var status = "Aprovado";
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Organizacao("12345678000195", endereco, 11, status));
            Assert.Equal("A nota média deve estar entre 0 e 10.", ex.Message);
        }
        
    }
}
