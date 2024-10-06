using EventPlanApp.Domain.Entities;

public class ListaEspera
{
    public int Id { get; set; }
    public int EventoId { get; set; }
    public Evento Evento { get; set; }

    public Guid UsuarioFinalId { get; set; }
    public UsuarioFinal UsuarioFinal { get; set; }
}
