namespace EventPlanApp.Domain.Entities;

public class Ingresso
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string TipoIngresso { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataCompra { get; set; }
    public bool IsValido { get; set; }

    public Usuario? Usuario { get; set; }
    public string? UsuarioId { get; set; }

    public Evento? Evento { get; set; }
    public string? EventoId { get; set; }
}