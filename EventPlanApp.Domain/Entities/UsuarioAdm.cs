using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class UsuarioAdm
    {
        public int AdmId { get; set; }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                ValidateEmail(value);
                _email = value;
            }
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set
            {
                ValidateSenha(value);
                _senha = value;
            }
        }

        private string _nomeUsuario;
        public string NomeUsuario
        {
            get => _nomeUsuario;
            set
            {
                ValidateNomeUsuario(value);
                _nomeUsuario = value;
            }
        }

        private string _telefone;
        public string Telefone
        {
            get => _telefone;
            set
            {
                ValidateTelefone(value);
                _telefone = value;
            }
        }

        public virtual ICollection<Organizacao> Organizacoes { get; set; } = new List<Organizacao>();

        // Validações
        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O e-mail é obrigatório.");
            }

            // Validação simples de e-mail
            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new ArgumentException("O e-mail deve ser válido.");
            }
        }

        private void ValidateSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new ArgumentException("A senha é obrigatória.");
            }
            if (senha.Length < 6)
            {
                throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");
            }
        }

        private void ValidateNomeUsuario(string nomeUsuario)
        {
            if (string.IsNullOrWhiteSpace(nomeUsuario))
            {
                throw new ArgumentException("O nome de usuário é obrigatório.");
            }
        }

        private void ValidateTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                throw new ArgumentException("O telefone é obrigatório.");
            }

            // Validação simples para telefone
            if (telefone.Length < 10 || telefone.Length > 15)
            {
                throw new ArgumentException("O telefone deve ter entre 10 e 15 caracteres.");
            }
        }
    }

}
