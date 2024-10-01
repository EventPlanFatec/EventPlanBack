using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class UsuarioFinal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O sobrenome não pode exceder 100 caracteres.")]
        public string Sobrenome { get; set; }

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
        [StringLength(2, ErrorMessage = "O estado deve conter 2 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 00000-000.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email fornecido é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone fornecido é inválido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O DDD é obrigatório.")]
        [StringLength(3, ErrorMessage = "O DDD deve ter 2 ou 3 dígitos.")]
        public string DDD { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [StringLength(100, ErrorMessage = "A preferência não pode exceder 100 caracteres.")]
        public string Preferencias01 { get; set; }

        [StringLength(100, ErrorMessage = "A preferência não pode exceder 100 caracteres.")]
        public string Preferencias02 { get; set; }

        [StringLength(100, ErrorMessage = "A preferência não pode exceder 100 caracteres.")]
        public string Preferencias03 { get; set; }

        public ICollection<Ingresso> Ingressos { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
