using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string NomeEvento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFim { get; set; }
        public int LotacaoMaxima { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Tipo { get; set; }
        public string Imagem01 { get; set; }
        public string Imagem02 { get; set; }
        public string Imagem03 { get; set; }
        public string Video { get; set; }
        public decimal NotaMedia { get; set; }
        public string Genero { get; set; }

        public ICollection<Ingresso> Ingressos { get; set; }

        public int OrganizacaoId { get; set; }
        public Organizacao Organizacao { get; set; }
    }

}
