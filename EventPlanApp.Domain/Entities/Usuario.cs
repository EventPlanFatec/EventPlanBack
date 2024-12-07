using System.Text.RegularExpressions;

namespace EventPlanApp.Domain.Entities;

public class Usuario
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Cpf { get; set; }
    public DateTime CreatedAt { get; set; }
    public string DataNascimento { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public Endereco? Endereco { get; set; }
    public string? EnderecoId { get; set; }

    public Role? Role { get; set; }
    public string? RoleId { get; set; }

    public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    public ICollection<Ingresso> Ingressos { get; set; } = new List<Ingresso>();
    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}