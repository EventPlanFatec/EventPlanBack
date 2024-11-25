using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EventPlanApp.Domain.Entities
{
    public class UsuarioFinal
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public int EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; private set; }

        public string DDD { get; private set; }
        public string? Preferencias { get; private set; }
        
        public virtual ICollection<Evento> Eventos { get; private set; } = new List<Evento>();

        public DateTime DataNascimento { get; private set; }

        public ICollection<Ingresso> Ingressos { get; set; } = new List<Ingresso>();
        public virtual ICollection<ListaEspera> ListasEspera { get; set; } = new List<ListaEspera>();
        public Guid? RoleId { get; private set; }
        public virtual Role Role { get; private set; }  // Relacionamento com Role
        public string Tema { get; private set; } = "light"; // Padrão: "light"
        public bool IsActive { get; set; }
        public virtual ICollection<EventPreference> EventPreferences { get; set; } = new List<EventPreference>(); // Nova linha
        public UsuarioFinal(string nome, string sobrenome, Endereco endereco, string email,
                            string telefone, string ddd, DateTime dataNascimento)
        {
            ValidateDomain(nome, sobrenome, endereco, email, telefone, ddd, dataNascimento);
        }

        public UsuarioFinal() { }

        private void ValidateDomain(string nome, string sobrenome, Endereco endereco, string email,
                                    string telefone, string ddd, DateTime dataNascimento)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.");
            if (nome.Length < 3 || nome.Length > 100)
                throw new ArgumentException("O nome deve ter entre 3 e 100 caracteres.");

            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException("Sobrenome não pode ser nulo ou vazio.");
            if (sobrenome.Length < 3 || sobrenome.Length > 100)
                throw new ArgumentException("O sobrenome deve ter entre 3 e 100 caracteres.");

            if (endereco == null)
                throw new ArgumentException("Endereço não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email deve ser um formato válido.");

            if (string.IsNullOrWhiteSpace(telefone))
                throw new ArgumentException("Telefone não pode ser nulo ou vazio.");

            if (string.IsNullOrWhiteSpace(ddd) || ddd.Length != 2)
                throw new ArgumentException("DDD deve ter exatamente 2 caracteres.");

            if (dataNascimento >= DateTime.Now)
                throw new ArgumentException("Data de nascimento não pode ser uma data futura.");

            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            DDD = ddd;
            DataNascimento = dataNascimento;
        }
        public void AssignRole(Guid roleId)
        {
            RoleId = roleId;
        }

        public void SetTema(string tema)
        {
            if (tema != "light" && tema != "dark")
                throw new ArgumentException("Tema inválido. Escolha entre 'light' ou 'dark'.");

            Tema = tema;
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser nulo ou vazio.");
            if (nome.Length < 3 || nome.Length > 100)
                throw new ArgumentException("O nome deve ter entre 3 e 100 caracteres.");

            Nome = nome;
        }

        public void SetSobrenome(string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException("Sobrenome não pode ser nulo ou vazio.");
            if (sobrenome.Length < 3 || sobrenome.Length > 100)
                throw new ArgumentException("O sobrenome deve ter entre 3 e 100 caracteres.");

            Sobrenome = sobrenome;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email deve ser um formato válido.");

            Email = email;
        }

    }
}
