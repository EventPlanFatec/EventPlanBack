using EventPlanApp.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlanApp.Domain.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace EventPlanApp.Domain.Tests
{


    public class EventoTests
    {
        private readonly EventoValidator _validator;

        public EventoTests()
        {
            _validator = new EventoValidator();
        }

        [Fact]
        public void NomeEvento_Nulo_Should_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.NomeEvento = null);
            Assert.Equal("Nome do evento não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.NomeEvento = string.Empty);
            Assert.Equal("Nome do evento não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void Descricao_Nula_Should_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.Descricao = null);
            Assert.Equal("Descrição não pode ser nula ou vazia.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.Descricao = string.Empty);
            Assert.Equal("Descrição não pode ser nula ou vazia.", exception.Message);
        }

        [Fact]
        public void Descricao_Should_ThrowArgumentException_When_NullOrEmpty()
        {
            // Arrange
            var evento = new Evento();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => evento.Descricao = null)
                .Message.Should().Be("Descrição não pode ser nula ou vazia.");

            Assert.Throws<ArgumentException>(() => evento.Descricao = "")
                .Message.Should().Be("Descrição não pode ser nula ou vazia.");
        }

        [Fact]
        public void Descricao_Should_ThrowArgumentException_When_Exceeds_Max_Length()
        {
            // Arrange
            var evento = new Evento();

            // Act
            Action act = () => evento.Descricao = new string('a', 1001);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("A descrição não pode exceder 1000 caracteres.");
        }



        [Fact]
        public void DataInicio_No_Passado_Should_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.DataInicio = DateTime.Now.AddDays(-1));
            Assert.Equal("Data de início não pode ser no passado.", exception.Message);
        }

        [Fact]
        public void DataFim_Menor_Ou_Igual_DataInicio_Should_Have_Error()
        {
            var evento = new Evento();

            // Primeiro, defina uma data de início válida
            evento.DataInicio = DateTime.Now.AddDays(1); // Data de início no futuro

            // Agora, verifique a data de fim
            var exception = Assert.Throws<ArgumentException>(() => evento.DataFim = evento.DataInicio.AddDays(-1)); // Tentar definir a data de fim para um dia antes da data de início
            Assert.Equal("Data de fim deve ser maior que a data de início.", exception.Message);
        }

        [Fact]
        public void HorarioInicio_Fora_do_Range_Should_Have_Error()
        {
            var evento = new Evento();

            // Testando horário fora do intervalo (antes de 06:00)
            var exception = Assert.Throws<ArgumentException>(() => evento.HorarioInicio = TimeSpan.FromHours(5));
            Assert.Equal("Horário de início deve estar entre 06:00 e 22:00.", exception.Message);

            // Testando horário fora do intervalo (após 22:00)
            exception = Assert.Throws<ArgumentException>(() => evento.HorarioInicio = TimeSpan.FromHours(23));
            Assert.Equal("Horário de início deve estar entre 06:00 e 22:00.", exception.Message);
        }

        [Fact]
        public void HorarioFim_Menor_Que_HorarioInicio_Should_Have_Error()
        {
            var evento = new Evento();

            // Definindo um horário de início válido
            evento.HorarioInicio = TimeSpan.FromHours(10);

            // Testando se a exceção é lançada quando HorarioFim é menor que HorarioInicio
            var exception = Assert.Throws<ArgumentException>(() => evento.HorarioFim = TimeSpan.FromHours(9));
            Assert.Equal("Horário de fim deve ser maior que o horário de início.", exception.Message);
        }


        [Fact]
        public void LotacaoMaxima_Negativa_Should_Have_Error()
        {
            var evento = new Evento();

            // Tenta definir uma lotação máxima negativa e espera uma exceção
            var exception = Assert.Throws<ArgumentException>(() => evento.LotacaoMaxima = -1);
            Assert.Equal("Lotação máxima não pode ser negativa.", exception.Message);
        }

        // Adicione um novo teste para verificar a validação durante a criação do evento, se necessário
        [Fact]
        public void LotacaoMaxima_Zero_Should_Not_Have_Error()
        {
            var evento = new Evento();

            // Tenta definir uma lotação máxima válida (zero) e não deve gerar exceção
            evento.LotacaoMaxima = 0;
            Assert.Equal(0, evento.LotacaoMaxima);
        }

        [Fact]
        public void TipoLogradouro_Nulo_Should_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.TipoLogradouro = null);
            Assert.Equal("Tipo de logradouro não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.TipoLogradouro = string.Empty);
            Assert.Equal("Tipo de logradouro não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void Logradouro_Nulo_Should_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.Logradouro = null);
            Assert.Equal("Logradouro não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.Logradouro = string.Empty);
            Assert.Equal("Logradouro não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void NumeroCasa_Nulo_Should_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.NumeroCasa = null);
            Assert.Equal("Número da casa não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.NumeroCasa = string.Empty);
            Assert.Equal("Número da casa não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void Bairro_Nulo_Should_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.Bairro = null);
            Assert.Equal("Bairro não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.Bairro = string.Empty);
            Assert.Equal("Bairro não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void Cidade_Nula_Should_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.Cidade = null);
            Assert.Equal("Cidade não pode ser nula ou vazia.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.Cidade = string.Empty);
            Assert.Equal("Cidade não pode ser nula ou vazia.", exception.Message);
        }

        [Fact]
        public void Estado_Nulo_Ou_Invalido_Should_Have_Error()
        {
            var evento = new Evento();

            // Testa o valor nulo
            var exception = Assert.Throws<ArgumentException>(() => evento.Estado = null);
            Assert.Equal("Estado não pode ser nulo ou vazio.", exception.Message);

            // Testa o valor vazio
            exception = Assert.Throws<ArgumentException>(() => evento.Estado = string.Empty);
            Assert.Equal("Estado não pode ser nulo ou vazio.", exception.Message);

            // Testa um estado inválido com menos de 2 caracteres
            exception = Assert.Throws<ArgumentException>(() => evento.Estado = "A");
            Assert.Equal("Estado deve ter exatamente 2 caracteres.", exception.Message);

            // Testa um estado inválido com mais de 2 caracteres
            exception = Assert.Throws<ArgumentException>(() => evento.Estado = "ABC");
            Assert.Equal("Estado deve ter exatamente 2 caracteres.", exception.Message);
        }

        [Fact]
        public void CEP_Invalido_Should_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.CEP = null);
            Assert.Equal("CEP não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.CEP = string.Empty);
            Assert.Equal("CEP não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.CEP = "1234-567"); // Formato inválido
            Assert.Equal("CEP deve ser um formato válido (XXXXX-XXX).", exception.Message);
        }

        [Fact]
        public void Tipo_Nulo_Should_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.Tipo = null);
            Assert.Equal("Tipo não pode ser nulo ou vazio.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.Tipo = string.Empty);
            Assert.Equal("Tipo não pode ser nulo ou vazio.", exception.Message);
        }

        [Fact]
        public void Imagem_Valida_Should_Nao_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.Imagem01 = new string('a', 201));
            Assert.Equal("A imagem não pode exceder 200 caracteres.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.Imagem02 = new string('a', 201));
            Assert.Equal("A imagem não pode exceder 200 caracteres.", exception.Message);

            exception = Assert.Throws<ArgumentException>(() => evento.Imagem03 = new string('a', 201));
            Assert.Equal("A imagem não pode exceder 200 caracteres.", exception.Message);
        }

        [Fact]
        public void Video_Valido_Should_Nao_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.Video = new string('a', 201));
            Assert.Equal("O vídeo não pode exceder 200 caracteres.", exception.Message);
        }

        [Fact]
        public void Genero_Valido_Should_Nao_Have_Error()
        {
            var evento = new Evento();

            var exception = Assert.Throws<ArgumentException>(() => evento.Genero = new string('a', 51));
            Assert.Equal("O gênero não pode exceder 50 caracteres.", exception.Message);
        }

        [Fact]
        public void Evento_Valido_Should_Not_Have_Errors()
        {
            var evento = new Evento
            {
                NomeEvento = "Evento Teste",
                Descricao = "Descrição do evento de teste.", // Adicionando a descrição corretamente
                DataInicio = DateTime.Now.AddDays(1),
                DataFim = DateTime.Now.AddDays(2),
                HorarioInicio = new TimeSpan(10, 0, 0),
                HorarioFim = new TimeSpan(12, 0, 0),
                LotacaoMaxima = 100,
                TipoLogradouro = "Rua",
                Logradouro = "Testes",
                NumeroCasa = "123",
                Bairro = "Centro",
                Cidade = "Cidade Exemplo",
                Estado = "SP",
                CEP = "12345-678",
                Tipo = "Cultural",
                Imagem01 = "imagem1.jpg",
                Imagem02 = "imagem2.jpg",
                Imagem03 = "imagem3.jpg",
                Video = "video.mp4",
                NotaMedia = 8,
                Genero = "Aventura"
            };

            var result = _validator.TestValidate(evento);
            result.ShouldNotHaveAnyValidationErrors();
        }

    }

}
