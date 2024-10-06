namespace EventPlanApp.Application.DTOs
{
    public class UsuarioAdmDto
    {
        public int AdmId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string NomeUsuario { get; set; }
        public string Telefone { get; set; }
        public int OrganizacaoId { get; set; }
    }

}
