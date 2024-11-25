public class CreateEventRequest
{
    public string NomeEvento { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Tipo { get; set; } // Ex: "Cultural", "Esportivo", etc.
    public string Logradouro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public bool Privacidade { get; set; } // true = Público, false = Privado
    public List<string> ListaConvidados { get; set; } // Lista de e-mails para eventos privados
}

