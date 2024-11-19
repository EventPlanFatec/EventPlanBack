using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlanApp.Domain.Entities
{
    public class Favorite
    {
        [Key]  // Chave primária da tabela
        public int Id { get; set; }

        [Required]  // O UserId não pode ser nulo
        [StringLength(50)]  // Limitar o tamanho do campo
        public string UserId { get; set; }  // Identificador do usuário que favoritou

        [Required]  // O EventoId não pode ser nulo
        public int EventoId { get; set; }  // Identificador do evento favorito

        // Relacionamento com a entidade Evento
        // Caso o relacionamento seja desejado, você pode incluir a propriedade Evento
        // que representa o evento que o usuário favoritou.
        public virtual Evento Evento { get; set; }
        public UsuarioFinal UsuarioFinal { get; set; }

        public int UsuarioFinalId { get; set; }
    }
}
