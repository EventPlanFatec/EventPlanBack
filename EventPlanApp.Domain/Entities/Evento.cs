using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EventPlanApp.Domain.Entities
{
    public class Evento
    {
        public int EventoId { get; private set; }
        public string NomeEvento { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public string Tipo { get; set; }
        public string Logradouro { get; set; }
        public TimeSpan HorarioInicio { get; private set; }
        public TimeSpan HorarioFim { get; private set; }
        public int LotacaoMaxima { get; private set; }
        public int EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }
        public EventoStatus Status { get; private set; }
        public List<Tag> Tags { get; set; }
        public bool Privacidade { get; set; } // true = Público, false = Privado
        public bool Publicado { get; set; }


        public string ListaConvidadosSerializada
        {
            get => string.Join(",", ListaConvidados ?? new List<string>());
            set => ListaConvidados = value?.Split(',').ToList() ?? new List<string>();
        }

        [NotMapped]
        public List<string> ListaConvidados { get; set; } = new List<string>();


        public string Imagens
        {
            get => string.Join(",", _imagens);
            private set => _imagens = value?.Split(',').ToList() ?? new List<string>();
        }

        private List<string> _imagens = new List<string>();

        public string Video { get; private set; }
        public decimal NotaMedia { get; set; }
        public string Genero { get; private set; }
        public ICollection<Ingresso> Ingressos { get; private set; } = new List<Ingresso>();
        public virtual ICollection<ListaEspera> ListasEspera { get; private set; } = new List<ListaEspera>();
        public virtual ICollection<UsuarioFinal> UsuariosFinais { get; private set; } = new List<UsuarioFinal>();
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();
        public ICollection<EventoCategoria> EventoCategorias { get; set; }
        public int OrganizacaoId { get; private set; }
        public Organizacao Organizacao { get; private set; }
        public int IngressosVendidos => Ingressos.Count;
        public int VagasDisponiveis => LotacaoMaxima - IngressosVendidos;
        public bool IsPrivate { get; set; }
        public string? PasswordHash { get; set; }
        

        public enum EventoStatus
        {
            Ativo,
            Cancelado
        }

        // Construtor
        public Evento(string nomeEvento, string descricao, DateTime dataInicio, DateTime dataFim,
                      TimeSpan horarioInicio, TimeSpan horarioFim, int lotacaoMaxima, Endereco endereco,
                      ICollection<string> imagens, string video, string genero)
        {
            ValidateDomain(nomeEvento, descricao, dataInicio, dataFim, horarioInicio, horarioFim,
                           lotacaoMaxima, endereco, imagens, video, genero);

            NomeEvento = nomeEvento;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            HorarioInicio = horarioInicio;
            HorarioFim = horarioFim;
            LotacaoMaxima = lotacaoMaxima;
            Endereco = endereco;
            Status = EventoStatus.Ativo;
            Imagens = string.Join(",", imagens);
            Video = video;
            Genero = genero;
        }

        public void Cancelar()
        {
            Status = EventoStatus.Cancelado;
        }

        public Evento() { }

        public void AdicionarUsuarioListaEspera(UsuarioFinal usuario)
        {
            if (!ListasEspera.Any(l => l.UsuarioFinalId == usuario.Id))
            {
                ListasEspera.Add(new ListaEspera { UsuarioFinal = usuario, Evento = this });
            }
        }

        public void AtualizarEvento(string nomeEvento, DateTime dataInicio, DateTime dataFim, TimeSpan horarioInicio, TimeSpan horarioFim, int lotacaoMaxima)
        {
            NomeEvento = nomeEvento;
            DataInicio = dataInicio;
            DataFim = dataFim;
            HorarioInicio = horarioInicio;
            HorarioFim = horarioFim;
            LotacaoMaxima = lotacaoMaxima;
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentException("Categoria não pode ser nula.");

            if (!Categorias.Any(c => c.CategoriaId == categoria.CategoriaId))
                Categorias.Add(categoria);
        }

        public void RemoverCategoria(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentException("Categoria não pode ser nula.");

            if (Categorias.Any(c => c.CategoriaId == categoria.CategoriaId))
                Categorias.Remove(categoria);
        }

        private void ValidateDomain(string nomeEvento, string descricao, DateTime dataInicio,
                                    DateTime dataFim, TimeSpan horarioInicio, TimeSpan horarioFim,
                                    int lotacaoMaxima, Endereco endereco, ICollection<string> imagens,
                                    string video, string genero)
        {
            if (string.IsNullOrWhiteSpace(nomeEvento))
                throw new ArgumentException("Nome do evento não pode ser nulo ou vazio.");
            if (string.IsNullOrWhiteSpace(descricao) || descricao.Length > 1000)
                throw new ArgumentException("Descrição inválida. Deve ter no máximo 1000 caracteres.");
            if (dataInicio < DateTime.Now)
                throw new ArgumentException("Data de início não pode ser no passado.");
            if (dataFim <= dataInicio)
                throw new ArgumentException("Data de fim deve ser maior que a data de início.");
            if (horarioInicio < TimeSpan.FromHours(6) || horarioInicio > TimeSpan.FromHours(22))
                throw new ArgumentException("Horário de início deve estar entre 06:00 e 22:00.");
            if (horarioFim <= horarioInicio)
                throw new ArgumentException("Horário de fim deve ser maior que o horário de início.");
            if (lotacaoMaxima < 0)
                throw new ArgumentException("Lotação máxima não pode ser negativa.");
            if (endereco == null)
                throw new ArgumentException("Endereço não pode ser nulo.");
            if (imagens == null || imagens.Count == 0)
                throw new ArgumentException("Deve haver pelo menos uma imagem.");
            foreach (var imagem in imagens)
            {
                if (imagem.Length > 200)
                    throw new ArgumentException("Cada imagem não pode exceder 200 caracteres.");
            }
            if (!string.IsNullOrWhiteSpace(video) && video.Length > 200)
                throw new ArgumentException("O link do vídeo não pode exceder 200 caracteres.");
            if (!string.IsNullOrWhiteSpace(genero) && genero.Length > 50)
                throw new ArgumentException("O gênero não pode exceder 50 caracteres.");
        }
        public void AdicionarConvidados(List<string> emails)
        {
            if (emails == null || emails.Count == 0)
                throw new ArgumentException("A lista de e-mails não pode ser nula ou vazia.");

            // Verifica se o evento é privado
            if (Privacidade == false)
                throw new InvalidOperationException("Este evento não é privado, portanto não pode ter convidados adicionados.");

            foreach (var email in emails)
            {
                if (!ListaConvidados.Contains(email))
                {
                    ListaConvidados.Add(email);
                }
            }
        }

        public void AtualizarPrivacidade(bool novaPrivacidade)
        {
            // Atualiza a privacidade
            Privacidade = novaPrivacidade;

            // Notifica os convidados caso o evento tenha convidados e seja privado
            if (!Privacidade && ListaConvidados.Any())
            {
                // Enviar notificação por e-mail para todos os convidados
                foreach (var email in ListaConvidados)
                {
                    // Chamar a função de envio de e-mail
                    EnviarNotificacaoPrivacidadeAlterada(email);
                }
            }
        }

        private void EnviarNotificacaoPrivacidadeAlterada(string email)
        {
            // Implementação para enviar e-mail informando sobre a mudança de privacidade
            // (Aqui seria necessário integração com um serviço de e-mail, como SendGrid ou SMTP)
            Console.WriteLine($"Notificando {email}: A privacidade do evento foi alterada.");
        }

    }
}
