namespace EventPlanApp.Application.DTOs
{
    public class OrganizacaoDto
    {
        public int OrganizacaoId { get; set; }
        public string CNPJ { get; set; }
        public decimal NotaMedia { get; set; }
        public EnderecoDto Endereco { get; set; }
        public ICollection<UsuarioAdmDto> UsuariosAdm { get; set; } = new List<UsuarioAdmDto>();
        public ICollection<EventoDto> Eventos { get; set; } = new List<EventoDto>();
        public string Message { get; set; }
    }

}
