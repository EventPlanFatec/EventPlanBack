namespace EventPlanApp.Domain.Entities;

public class Role
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<string> Permissoes { get; set; } = new List<string>();
}