using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Tests.Domain.Entities
{
    public class IngressoTests
    {
        [Fact]
        public void CriarIngresso_Valido_DeveFuncionar()
        {
            // Act
            var ingresso = new Ingresso(100, "QRCode", "Evento Teste", DateTime.Now.AddDays(1));

            // Assert
            Assert.NotNull(ingresso);
        }

        [Fact]
        public void CriarIngresso_ValorNegativo_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(-1, "QRCode", "Evento Teste", DateTime.Now.AddDays(1)));
            Assert.Equal("O valor deve ser maior que zero.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_ValorZero_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(0, "QRCode", "Evento Teste", DateTime.Now.AddDays(1)));
            Assert.Equal("O valor deve ser maior que zero.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_QRCodeNulo_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(100, null, "Evento Teste", DateTime.Now.AddDays(1)));
            Assert.Equal("O QRCode é obrigatório.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_QRCodeVazio_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(100, string.Empty, "Evento Teste", DateTime.Now.AddDays(1)));
            Assert.Equal("O QRCode é obrigatório.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_NomeEventoNulo_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(100, "QRCode", null, DateTime.Now.AddDays(1)));
            Assert.Equal("O nome do evento é obrigatório.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_NomeEventoVazio_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(100, "QRCode", string.Empty, DateTime.Now.AddDays(1)));
            Assert.Equal("O nome do evento é obrigatório.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_DataPassada_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(100, "QRCode", "Evento Teste", DateTime.Now.AddDays(-1)));
            Assert.Equal("A data não pode ser no passado.", ex.Message);
        }
    }
}
