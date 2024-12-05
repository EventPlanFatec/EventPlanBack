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
    public List<string> UsuariosIds { get; set; } = new List<string>();
    public List<string> EventosIds { get; set; } = new List<string>();
}