namespace EventPlanApp.Domain.Entities;

public class Endereco
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Logradouro { get; set; }
    public string NumeroPredial { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }

    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}