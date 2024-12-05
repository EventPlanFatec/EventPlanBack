namespace EventPlanApp.Application.DTOs;
public class IngressoDTO
{
    public string Id { get; set; }
    public string EventoId { get; set; }
    public string UsuarioId { get; set; }
    public string TipoIngresso { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataCompra { get; set; }
    public bool IsValido { get; set; }
}