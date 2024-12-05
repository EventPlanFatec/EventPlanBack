using System.Text.RegularExpressions;

namespace EventPlanApp.Domain.Entities;

public class Usuario
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string EnderecoId { get; set; }
    public string RoleId { get; set; }
    public string Cpf { get; set; }
    public DateTime CreatedAt { get; set; }
    public string DataNascimento { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public List<string> IngressosIds { get; set; } = new List<string>();
    public List<string> EventosIds { get; set; } = new List<string>();
}