using EventPlanApp.Domain.Entities;

public class EventPreference
{
    public int Id { get; set; }
    public int UserId { get; set; } // Relacionamento com o usuário
    public string EventType { get; set; } // Tipo de evento
    public string Location { get; set; } // Localização preferida
    public decimal MinPrice { get; set; } // Faixa de preço mínima
    public decimal MaxPrice { get; set; } // Faixa de preço máxima

    // Propriedade de navegação (caso tenha relação com a entidade User, por exemplo)
    public UsuarioFinal UsuarioFinal { get; set; }
}