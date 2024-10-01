using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class Organizacao
    {
        [Key]
        public int OrganizacaoId { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}", ErrorMessage = "O CNPJ deve estar no formato 00.000.000/0000-00.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O tipo de logradouro é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tipo de logradouro não pode exceder 50 caracteres.")]
        public string TipoLogradouro { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        [StringLength(150, ErrorMessage = "O logradouro não pode exceder 150 caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O número do prédio é obrigatório.")]
        [StringLength(10, ErrorMessage = "O número do prédio não pode exceder 10 caracteres.")]
        public string NumeroPredio { get; set; }

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

        [Range(0, 5, ErrorMessage = "A nota média deve estar entre 0 e 5.")]
        public decimal NotaMedia { get; set; }


        [Required]
        public int UsuarioAdmId { get; set; }

        public virtual ICollection<UsuarioAdm> UsuariosAdm { get; set; } = new List<UsuarioAdm>();

        public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
