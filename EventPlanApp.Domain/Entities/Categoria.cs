namespace EventPlanApp.Domain.Entities;
public class Categoria
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Nome { get; set; }
    public string Descricao { get; set; }
}
