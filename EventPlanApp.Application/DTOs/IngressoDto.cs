namespace EventPlanApp.Application.DTOs
{
    public class IngressoDto
    {
        public int IngressoId { get; set; }
        public decimal Valor { get; set; }
        public string QRCode { get; set; }
        public string NomeEvento { get; set; }
        public DateTime Data { get; set; }
        public Guid UsuarioFinalId { get; set; }
        public int EventoId { get; set; }
        public bool Vip { get; set; }
    }

}
