using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class Evento
    {
        public int EventoId { get; set; }

        private string _nomeEvento;
        public string NomeEvento
        {
            get => _nomeEvento;
            set
            {
                ValidateNomeEvento(value);
                _nomeEvento = value;
            }
        }

        private string _descricao;
        public string Descricao
        {
            get => _descricao;
            set
            {
                ValidateDescricao(value);
                _descricao = value;
            }
        }

        private DateTime _dataInicio;
        public DateTime DataInicio
        {
            get => _dataInicio;
            set
            {
                ValidateDataInicio(value);
                _dataInicio = value;
            }
        }

        private DateTime _dataFim;
        public DateTime DataFim
        {
            get => _dataFim;
            set
            {
                ValidateDataFim(value);
                _dataFim = value;
            }
        }

        private TimeSpan _horarioInicio;
        public TimeSpan HorarioInicio
        {
            get => _horarioInicio;
            set
            {
                ValidateHorarioInicio(value);
                _horarioInicio = value;
            }
        }

        private TimeSpan _horarioFim;
        public TimeSpan HorarioFim
        {
            get => _horarioFim;
            set
            {
                ValidateHorarioFim(value);
                _horarioFim = value;
            }
        }

        private int _lotacaoMaxima;
        public int LotacaoMaxima
        {
            get => _lotacaoMaxima;
            set
            {
                ValidateLotacaoMaxima(value);
                _lotacaoMaxima = value;
            }
        }

        private string _tipoLogradouro;
        public string TipoLogradouro
        {
            get => _tipoLogradouro;
            set
            {
                ValidateTipoLogradouro(value);
                _tipoLogradouro = value;
            }
        }

        private string _logradouro;
        public string Logradouro
        {
            get => _logradouro;
            set
            {
                ValidateLogradouro(value);
                _logradouro = value;
            }
        }

        private string _numeroCasa;
        public string NumeroCasa
        {
            get => _numeroCasa;
            set
            {
                ValidateNumeroCasa(value);
                _numeroCasa = value;
            }
        }

        private string _bairro;
        public string Bairro
        {
            get => _bairro;
            set
            {
                ValidateBairro(value);
                _bairro = value;
            }
        }

        private string _cidade;
        public string Cidade
        {
            get => _cidade;
            set
            {
                ValidateCidade(value);
                _cidade = value;
            }
        }

        private string _estado;
        public string Estado
        {
            get => _estado;
            set
            {
                ValidateEstado(value);
                _estado = value;
            }
        }

        private string _cep;
        public string CEP
        {
            get => _cep;
            set
            {
                ValidateCEP(value);
                _cep = value;
            }
        }

        private string _tipo;
        public string Tipo
        {
            get => _tipo;
            set
            {
                ValidateTipo(value);
                _tipo = value;
            }
        }

        private string _imagem01;
        public string Imagem01
        {
            get => _imagem01;
            set
            {
                ValidateImagem(value);
                _imagem01 = value;
            }
        }

        private string _imagem02;
        public string Imagem02
        {
            get => _imagem02;
            set
            {
                ValidateImagem(value);
                _imagem02 = value;
            }
        }

        private string _imagem03;
        public string Imagem03
        {
            get => _imagem03;
            set
            {
                ValidateImagem(value);
                _imagem03 = value;
            }
        }

        private string _video;
        public string Video
        {
            get => _video;
            set
            {
                ValidateVideo(value);
                _video = value;
            }
        }

        public decimal NotaMedia { get; set; }

        private string _genero;
        public string Genero
        {
            get => _genero;
            set
            {
                ValidateGenero(value);
                _genero = value;
            }
        }

        public ICollection<Ingresso> Ingressos { get; set; } = new List<Ingresso>();
        public ICollection<UsuarioFinal> UsuariosFinais { get; set; } = new List<UsuarioFinal>();

        public int OrganizacaoId { get; set; }
        public Organizacao Organizacao { get; set; }

        // Validações
        private void ValidateNomeEvento(string nomeEvento)
        {
            if (string.IsNullOrWhiteSpace(nomeEvento))
            {
                throw new ArgumentException("Nome do evento não pode ser nulo ou vazio.");
            }
        }

        private void ValidateDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("Descrição não pode ser nula ou vazia.");
            }

            if (descricao.Length > 1000)
            {
                throw new ArgumentException("A descrição não pode exceder 1000 caracteres.");
            }
        }

        private void ValidateDataInicio(DateTime value)
        {
            if (value < DateTime.Now)
                throw new ArgumentException("Data de início não pode ser no passado.");
        }

        private void ValidateDataFim(DateTime value)
        {
            if (value <= _dataInicio)
                throw new ArgumentException("Data de fim deve ser maior que a data de início.");
        }

        private void ValidateHorarioInicio(TimeSpan value)
        {
            if (value < TimeSpan.FromHours(6) || value > TimeSpan.FromHours(22))
                throw new ArgumentException("Horário de início deve estar entre 06:00 e 22:00.");
        }

        private void ValidateHorarioFim(TimeSpan value)
        {
            if (value <= _horarioInicio)
                throw new ArgumentException("Horário de fim deve ser maior que o horário de início.");
        }

        private void ValidateLotacaoMaxima(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Lotação máxima não pode ser negativa.");
            }
        }

        private void ValidateTipoLogradouro(string tipoLogradouro)
        {
            if (string.IsNullOrWhiteSpace(tipoLogradouro))
            {
                throw new ArgumentException("Tipo de logradouro não pode ser nulo ou vazio.");
            }
        }

        private void ValidateLogradouro(string logradouro)
        {
            if (string.IsNullOrWhiteSpace(logradouro))
            {
                throw new ArgumentException("Logradouro não pode ser nulo ou vazio.");
            }
        }

        private void ValidateNumeroCasa(string numeroCasa)
        {
            if (string.IsNullOrWhiteSpace(numeroCasa))
            {
                throw new ArgumentException("Número da casa não pode ser nulo ou vazio.");
            }
        }

        private void ValidateBairro(string bairro)
        {
            if (string.IsNullOrWhiteSpace(bairro))
            {
                throw new ArgumentException("Bairro não pode ser nulo ou vazio.");
            }
        }

        private void ValidateCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade))
            {
                throw new ArgumentException("Cidade não pode ser nula ou vazia.");
            }
        }

        private void ValidateEstado(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Estado não pode ser nulo ou vazio.");
            }

            if (value.Length != 2)
            {
                throw new ArgumentException("Estado deve ter exatamente 2 caracteres.");
            }
        }

        private void ValidateCEP(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("CEP não pode ser nulo ou vazio.");
            }

            // Exemplo de validação simples de CEP, supondo que seja um formato de 8 dígitos
            if (!Regex.IsMatch(value, @"^\d{5}-?\d{3}$"))
            {
                throw new ArgumentException("CEP deve ser um formato válido (XXXXX-XXX).");
            }
        }

        private void ValidateTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException("Tipo não pode ser nulo ou vazio.");
            }
        }

        private void ValidateImagem(string imagem)
        {
            if (!string.IsNullOrWhiteSpace(imagem) && imagem.Length > 200)
            {
                throw new ArgumentException("A imagem não pode exceder 200 caracteres.");
            }
        }

        private void ValidateVideo(string video)
        {
            if (!string.IsNullOrWhiteSpace(video) && video.Length > 200)
            {
                throw new ArgumentException("O vídeo não pode exceder 200 caracteres.");
            }
        }

        private void ValidateGenero(string genero)
        {
            if (!string.IsNullOrWhiteSpace(genero) && genero.Length > 50)
            {
                throw new ArgumentException("O gênero não pode exceder 50 caracteres.");
            }
        }
    }
}
