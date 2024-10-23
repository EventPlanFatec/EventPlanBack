using EventPlanApp.Domain.Entities;
using Xunit;

namespace EventPlanApp.Tests.Domain.Entities
{
    public class IngressoTests
    {
        [Fact]
        public void CriarIngresso_Valido_DeveFuncionar()
        {
            // Act
            var ingresso = new Ingresso(100, "QRCode", "Evento Teste", DateTime.Now.AddDays(1), true);

            // Assert
            Assert.NotNull(ingresso);
        }

        [Fact]
        public void CriarIngresso_ValorNegativo_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(-1, "QRCode", "Evento Teste", DateTime.Now.AddDays(1), true));
            Assert.Equal("O valor deve ser maior que zero.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_ValorZero_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(0, "QRCode", "Evento Teste", DateTime.Now.AddDays(1), true));
            Assert.Equal("O valor deve ser maior que zero.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_QRCodeNulo_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(100, null, "Evento Teste", DateTime.Now.AddDays(1), true));
            Assert.Equal("O QRCode é obrigatório.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_QRCodeVazio_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(100, string.Empty, "Evento Teste", DateTime.Now.AddDays(1), true));
            Assert.Equal("O QRCode é obrigatório.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_NomeEventoNulo_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(100, "QRCode", null, DateTime.Now.AddDays(1), true));
            Assert.Equal("O nome do evento é obrigatório.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_NomeEventoVazio_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(100, "QRCode", string.Empty, DateTime.Now.AddDays(1), true));
            Assert.Equal("O nome do evento é obrigatório.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_DataPassada_DeveLancarExcecao()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Ingresso(100, "QRCode", "Evento Teste", DateTime.Now.AddDays(-1), true));
            Assert.Equal("A data não pode ser no passado.", ex.Message);
        }

        [Fact]
        public void CriarIngresso_PropriedadesDevemSerDefinidasCorretamente()
        {
            // Arrange
            var valor = 150m;
            var qrCode = "QRCode123";
            var nomeEvento = "Evento Teste";
            var data = DateTime.Now.AddDays(10);
            var vip = true;

            // Act
            var ingresso = new Ingresso(valor, qrCode, nomeEvento, data, vip);

            // Assert
            Assert.Equal(valor, ingresso.Valor);
            Assert.Equal(qrCode, ingresso.QRCode);
            Assert.Equal(nomeEvento, ingresso.NomeEvento);
            Assert.Equal(data, ingresso.Data);
            Assert.True(ingresso.Vip);
        }

        [Fact]
        public void CriarIngresso_IdDeveSerGerado()
        {
            // Act
            var ingresso1 = new Ingresso(100, "QRCode1", "Evento 1", DateTime.Now.AddDays(1), true);
            var ingresso2 = new Ingresso(100, "QRCode2", "Evento 2", DateTime.Now.AddDays(1), true);

            // Assert
            Assert.NotEqual(ingresso1.IngressoId, ingresso2.IngressoId);
        }
    }
}
