using System.Collections.Generic;

namespace EventPlanApp.Domain.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public virtual ICollection<Evento> Eventos { get; private set; } = new List<Evento>();
        public ICollection<EventoCategoria> EventoCategorias { get; set; }

        public Categoria(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da categoria não pode ser nulo ou vazio.");

            Nome = nome;
        }
    }
}
