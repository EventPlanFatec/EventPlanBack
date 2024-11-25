using System;

namespace EventPlanApp.Application.DTOs
{
    public class CreateUserRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public EnderecoDto Endereco { get; set; }  // Alterado para usar EnderecoDto
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Ddd { get; set; }
        public DateTime DataNascimento { get; set; }

        // Construtor para inicializar os valores
        public CreateUserRequest(string nome, string sobrenome, EnderecoDto endereco, string email, string telefone, string ddd, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            Ddd = ddd;
            DataNascimento = dataNascimento;
        }
    }
}
