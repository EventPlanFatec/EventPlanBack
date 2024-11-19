using EventPlanApp.Domain.Entities;

public class EventoCategoria
{
    public Guid Id { get; set; }
    public int EventoId { get; set; }
    public Evento Evento { get; set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}
