using EventPlanApp.Domain.Entities;

public class Organizacao
{
    public int OrganizacaoId { get; private set; }
    public string CNPJ { get; private set; }
    public decimal NotaMedia { get; private set; }
    public virtual Endereco Endereco { get; private set; } 
    public virtual ICollection<UsuarioAdm> UsuariosAdm { get; private set; } = new List<UsuarioAdm>();
    public virtual ICollection<Evento> Eventos { get; private set; } = new List<Evento>();

    public Organizacao(string cnpj, Endereco endereco, decimal notaMedia)
    {
        ValidateDomain(cnpj, notaMedia);
        OrganizacaoId = new Random().Next(1, 1000); 
        CNPJ = cnpj; 
        Endereco = endereco; 
        NotaMedia = notaMedia; 
    }

    public Organizacao() { }

    private void ValidateDomain(string cnpj, decimal notaMedia)
    {
        if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14)
            throw new ArgumentException("O CNPJ deve ter 14 caracteres e é obrigatório.");

        if (notaMedia < 0 || notaMedia > 10)
            throw new ArgumentException("A nota média deve estar entre 0 e 10.");
    }
}
