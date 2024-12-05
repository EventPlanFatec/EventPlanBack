//using EventPlanApp.Domain.Entities;
//using Xunit;
//using System;
//using System.Collections.Generic;

//namespace EventPlanApp.Tests.Domain.Entities
//{
//    public class EventoTests
//    {
//        [Fact]
//        public void CriarEvento_Valido_DeveFuncionar()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");
//            var imagens = new List<string> { "imagem1.jpg" };

//            // Act
//            var evento = new Evento("Evento Teste", "Descrição válida", DateTime.Now.AddDays(1),
//                                    DateTime.Now.AddDays(2), TimeSpan.FromHours(8),
//                                    TimeSpan.FromHours(10), 100, endereco,
//                                    imagens, null, "Música");

//            // Assert
//            Assert.NotNull(evento);
//        }

//        [Fact]
//        public void CriarEvento_NomeInvalido_DeveLancarExcecao()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");
//            var imagens = new List<string> { "imagem1.jpg" };

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("", "Descrição válida",
//                DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), TimeSpan.FromHours(8),
//                TimeSpan.FromHours(10), 100, endereco, imagens, null, "Música"));
//            Assert.Equal("Nome do evento não pode ser nulo ou vazio.", ex.Message);
//        }

//        [Fact]
//        public void CriarEvento_DescricaoInvalida_DeveLancarExcecao()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");
//            var imagens = new List<string> { "imagem1.jpg" };

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("Evento Teste", "",
//                DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), TimeSpan.FromHours(8),
//                TimeSpan.FromHours(10), 100, endereco, imagens, null, "Música"));
//            Assert.Equal("Descrição inválida. Deve ter no máximo 1000 caracteres.", ex.Message);
//        }

//        [Fact]
//        public void CriarEvento_DataInicioNoPassado_DeveLancarExcecao()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");
//            var imagens = new List<string> { "imagem1.jpg" };

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("Evento Teste", "Descrição válida",
//                DateTime.Now.AddDays(-1), DateTime.Now.AddDays(2), TimeSpan.FromHours(8),
//                TimeSpan.FromHours(10), 100, endereco, imagens, null, "Música"));
//            Assert.Equal("Data de início não pode ser no passado.", ex.Message);
//        }

//        [Fact]
//        public void CriarEvento_DataFimAntesDeInicio_DeveLancarExcecao()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");
//            var imagens = new List<string> { "imagem1.jpg" };

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("Evento Teste", "Descrição válida",
//                DateTime.Now.AddDays(2), DateTime.Now.AddDays(1), TimeSpan.FromHours(8),
//                TimeSpan.FromHours(10), 100, endereco, imagens, null, "Música"));
//            Assert.Equal("Data de fim deve ser maior que a data de início.", ex.Message);
//        }

//        [Fact]
//        public void CriarEvento_HorarioInicioForaDoIntervalo_DeveLancarExcecao()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");
//            var imagens = new List<string> { "imagem1.jpg" };

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("Evento Teste", "Descrição válida",
//                DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), TimeSpan.FromHours(5),
//                TimeSpan.FromHours(10), 100, endereco, imagens, null, "Música"));
//            Assert.Equal("Horário de início deve estar entre 06:00 e 22:00.", ex.Message);
//        }

//        [Fact]
//        public void CriarEvento_HorarioFimAntesDeInicio_DeveLancarExcecao()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");
//            var imagens = new List<string> { "imagem1.jpg" };

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("Evento Teste", "Descrição válida",
//                DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), TimeSpan.FromHours(10),
//                TimeSpan.FromHours(8), 100, endereco, imagens, null, "Música"));
//            Assert.Equal("Horário de fim deve ser maior que o horário de início.", ex.Message);
//        }

//        [Fact]
//        public void CriarEvento_LotacaoMaximaNegativa_DeveLancarExcecao()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");
//            var imagens = new List<string> { "imagem1.jpg" };

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("Evento Teste", "Descrição válida",
//                DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), TimeSpan.FromHours(8),
//                TimeSpan.FromHours(10), -1, endereco, imagens, null, "Música"));
//            Assert.Equal("Lotação máxima não pode ser negativa.", ex.Message);
//        }

//        [Fact]
//        public void CriarEvento_EnderecoNulo_DeveLancarExcecao()
//        {
//            // Arrange
//            var imagens = new List<string> { "imagem1.jpg" };

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("Evento Teste", "Descrição válida",
//                DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), TimeSpan.FromHours(8),
//                TimeSpan.FromHours(10), 100, null, imagens, null, "Música"));
//            Assert.Equal("Endereço não pode ser nulo.", ex.Message);
//        }

//        [Fact]
//        public void CriarEvento_ImagensNulas_DeveLancarExcecao()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("Evento Teste", "Descrição válida",
//                DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), TimeSpan.FromHours(8),
//                TimeSpan.FromHours(10), 100, endereco, null, null, "Música"));
//            Assert.Equal("Deve haver pelo menos uma imagem.", ex.Message);
//        }

//        [Fact]
//        public void CriarEvento_ImagemExcedeTamanho_DeveLancarExcecao()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");
//            var imagens = new List<string> { new string('a', 201) }; // Imagem com mais de 200 caracteres

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("Evento Teste", "Descrição válida",
//                DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), TimeSpan.FromHours(8),
//                TimeSpan.FromHours(10), 100, endereco, imagens, null, "Música"));
//            Assert.Equal("Cada imagem não pode exceder 200 caracteres.", ex.Message);
//        }

//        [Fact]
//        public void CriarEvento_VideoExcedeTamanho_DeveLancarExcecao()
//        {
//            // Arrange
//            var endereco = new Endereco("Rua", "Rua Teste", "123", "Centro", "Cidade Teste", "SP", "00000-000");
//            var imagens = new List<string> { "imagem1.jpg" };
//            var video = new string('a', 201); // Video com mais de 200 caracteres

//            // Act & Assert
//            var ex = Assert.Throws<ArgumentException>(() => new Evento("Evento Teste", "Descrição válida",
//                DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), TimeSpan.FromHours(8),
//                TimeSpan.FromHours(10), 100, endereco, imagens, video, "Música"));
//            Assert.Equal("O link do vídeo não pode exceder 200 caracteres.", ex.Message);
//        }
//        [Fact]
//        public void Deve_Adicionar_Categoria_Ao_Evento()
//        {
//            var evento = new Evento("Evento Teste", "Descrição", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2),
//                                    TimeSpan.FromHours(10), TimeSpan.FromHours(12), 100, new Endereco(),
//                                    new List<string> { "imagem1.png" }, "video.mp4", "Gênero");
//            var categoria = new Categoria("Música");

//            evento.AdicionarCategoria(categoria);

//            Assert.Contains(categoria, evento.Categorias);
//        }

//        [Fact]
//        public void Deve_Remover_Categoria_Do_Evento()
//        {
//            var evento = new Evento("Evento Teste", "Descrição", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2),
//                                    TimeSpan.FromHours(10), TimeSpan.FromHours(12), 100, new Endereco(),
//                                    new List<string> { "imagem1.png" }, "video.mp4", "Gênero");
//            var categoria = new Categoria("Música");
//            evento.AdicionarCategoria(categoria);

//            evento.RemoverCategoria(categoria);

//            Assert.DoesNotContain(categoria, evento.Categorias);
//        }
//    }
//}
