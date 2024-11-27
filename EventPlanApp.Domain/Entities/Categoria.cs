using System.Collections.Generic;

namespace EventPlanApp.Domain.Entities
{
    public class Categoria
    {
        public Categoria(string nome)
        {
            Nome = nome;
        }

        public int CategoriaId { get; private set; }
        public string Nome { get; private set; }

    }
}
