using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }

        [Required(ErrorMessage = "O nome do evento é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome do evento não pode exceder 150 caracteres.")]
        public string NomeEvento { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de término é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O horário de início é obrigatório.")]
        [DataType(DataType.Time)]
        public TimeSpan HorarioInicio { get; set; }

        [Required(ErrorMessage = "O horário de término é obrigatório.")]
        [DataType(DataType.Time)]
        public TimeSpan HorarioFim { get; set; }

        [Required(ErrorMessage = "A lotação máxima é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A lotação máxima deve ser maior que 0.")]
        public int LotacaoMaxima { get; set; }

        [Required(ErrorMessage = "O tipo de logradouro é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tipo de logradouro não pode exceder 50 caracteres.")]
        public string TipoLogradouro { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        [StringLength(150, ErrorMessage = "O logradouro não pode exceder 150 caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O número da casa é obrigatório.")]
        [StringLength(10, ErrorMessage = "O número da casa não pode exceder 10 caracteres.")]
        public string NumeroCasa { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(100, ErrorMessage = "O bairro não pode exceder 100 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(100, ErrorMessage = "A cidade não pode exceder 100 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve ter 2 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "O CEP deve estar no formato 00000-000.")]
        public string CEP { get; set; }

        [StringLength(50, ErrorMessage = "O tipo de evento não pode exceder 50 caracteres.")]
        public string Tipo { get; set; }

        [Url(ErrorMessage = "A URL da imagem 01 deve ser válida.")]
        public string Imagem01 { get; set; }

        [Url(ErrorMessage = "A URL da imagem 02 deve ser válida.")]
        public string Imagem02 { get; set; }

        [Url(ErrorMessage = "A URL da imagem 03 deve ser válida.")]
        public string Imagem03 { get; set; }

        [Url(ErrorMessage = "A URL do vídeo deve ser válida.")]
        public string Video { get; set; }

        [Range(1.0, 5.0, ErrorMessage = "A nota média deve estar entre 1 e 5.")]
        public decimal NotaMedia { get; set; }

        [StringLength(50, ErrorMessage = "O gênero do evento não pode exceder 50 caracteres.")]
        public string Genero { get; set; }

        public ICollection<Ingresso> Ingressos { get; set; }

        [Required(ErrorMessage = "A organização é obrigatória.")]
        public int OrganizacaoId { get; set; }

        public Organizacao Organizacao { get; set; }
    }

}
