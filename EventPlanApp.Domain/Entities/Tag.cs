using EventPlanApp.Domain.Entities;

public class Tag
{
    public int TagId { get; set; }
    public string Nome { get; set; }

    public List<Evento> Eventos { get; set; } // Relacionamento com a tabela de Eventos
}
