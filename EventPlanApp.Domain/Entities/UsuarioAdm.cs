namespace EventPlanApp.Domain.Entities
{
    public class UsuarioAdm
    {
        public int AdmId { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string NomeUsuario { get; private set; }
        public string Telefone { get; private set; }

        public int OrganizacaoId { get; private set; }

        public virtual Organizacao Organizacao { get; private set; }

        public UsuarioAdm(string email, string senha, string nomeUsuario, string telefone)
        {
            ValidateDomain(email, senha, nomeUsuario, telefone);
            AdmId = new Random().Next(1, 1000);
            Email = email; 
            Senha = senha; 
            NomeUsuario = nomeUsuario; 
            Telefone = telefone;  
        }

        public UsuarioAdm() { }

        private void ValidateDomain(string email, string senha, string nomeUsuario, string telefone)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                throw new ArgumentException("O e-mail deve ser válido.");

            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6)
                throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");

            if (string.IsNullOrWhiteSpace(nomeUsuario))
                throw new ArgumentException("O nome de usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(telefone) || telefone.Length < 10 || telefone.Length > 15)
                throw new ArgumentException("O telefone deve ter entre 10 e 15 caracteres.");
        }
    }
}
