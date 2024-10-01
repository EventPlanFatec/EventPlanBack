using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Tests.Tests
{
    public class UsuarioFinalTests
    {
        [Fact]
        public void UsuarioFinal_ValidarNome_Obrigatorio()
        {
            var usuario = new UsuarioFinal { Nome = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O nome é obrigatório.");
        }

        [Fact]
        public void UsuarioFinal_ValidarNome_TamanhoMaximo()
        {
            var usuario = new UsuarioFinal { Nome = new string('A', 101) }; // Mais de 100 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O nome não pode exceder 100 caracteres.");
        }

        [Fact]
        public void UsuarioFinal_ValidarSobrenome_Obrigatorio()
        {
            var usuario = new UsuarioFinal { Sobrenome = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O sobrenome é obrigatório.");
        }

        [Fact]
        public void UsuarioFinal_ValidarSobrenome_TamanhoMaximo()
        {
            var usuario = new UsuarioFinal { Sobrenome = new string('A', 101) }; // Mais de 100 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O sobrenome não pode exceder 100 caracteres.");
        }

        [Fact]
        public void UsuarioFinal_ValidarTipoLogradouro_Obrigatorio()
        {
            var usuario = new UsuarioFinal { TipoLogradouro = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O tipo de logradouro é obrigatório.");
        }

        [Fact]
        public void UsuarioFinal_ValidarTipoLogradouro_TamanhoMaximo()
        {
            var usuario = new UsuarioFinal { TipoLogradouro = new string('A', 51) }; // Mais de 50 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O tipo de logradouro não pode exceder 50 caracteres.");
        }

        [Fact]
        public void UsuarioFinal_ValidarLogradouro_Obrigatorio()
        {
            var usuario = new UsuarioFinal { Logradouro = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O logradouro é obrigatório.");
        }

        [Fact]
        public void UsuarioFinal_ValidarLogradouro_TamanhoMaximo()
        {
            var usuario = new UsuarioFinal { Logradouro = new string('A', 151) }; // Mais de 150 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O logradouro não pode exceder 150 caracteres.");
        }

        [Fact]
        public void UsuarioFinal_ValidarNumeroCasa_Obrigatorio()
        {
            var usuario = new UsuarioFinal { NumeroCasa = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O número da casa é obrigatório.");
        }

        [Fact]
        public void UsuarioFinal_ValidarNumeroCasa_TamanhoMaximo()
        {
            var usuario = new UsuarioFinal { NumeroCasa = new string('A', 11) }; // Mais de 10 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O número da casa não pode exceder 10 caracteres.");
        }

        [Fact]
        public void UsuarioFinal_ValidarBairro_Obrigatorio()
        {
            var usuario = new UsuarioFinal { Bairro = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O bairro é obrigatório.");
        }

        [Fact]
        public void UsuarioFinal_ValidarBairro_TamanhoMaximo()
        {
            var usuario = new UsuarioFinal { Bairro = new string('A', 101) }; // Mais de 100 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O bairro não pode exceder 100 caracteres.");
        }

        [Fact]
        public void UsuarioFinal_ValidarCidade_Obrigatoria()
        {
            var usuario = new UsuarioFinal { Cidade = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A cidade é obrigatória.");
        }

        [Fact]
        public void UsuarioFinal_ValidarCidade_TamanhoMaximo()
        {
            var usuario = new UsuarioFinal { Cidade = new string('A', 101) }; // Mais de 100 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A cidade não pode exceder 100 caracteres.");
        }

        [Fact]
        public void UsuarioFinal_ValidarEstado_Obrigatorio()
        {
            var usuario = new UsuarioFinal { Estado = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O estado é obrigatório.");
        }

        [Fact]
        public void UsuarioFinal_ValidarEstado_TamanhoInvalido()
        {
            var usuario = new UsuarioFinal { Estado = "ABC" }; // Mais de 2 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O estado deve conter 2 caracteres.");
        }

        [Fact]
        public void UsuarioFinal_ValidarCEP_Obrigatorio()
        {
            var usuario = new UsuarioFinal { CEP = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O CEP é obrigatório.");
        }

        [Fact]
        public void UsuarioFinal_ValidarCEP_FormatoInvalido()
        {
            var usuario = new UsuarioFinal { CEP = "12345678" }; // Formato inválido
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O CEP deve estar no formato 00000-000.");
        }

        [Fact]
        public void UsuarioFinal_ValidarEmail_Obrigatorio()
        {
            var usuario = new UsuarioFinal { Email = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O email é obrigatório.");
        }

        [Fact]
        public void UsuarioFinal_ValidarEmail_FormatoInvalido()
        {
            var usuario = new UsuarioFinal { Email = "emailinvalido" }; // Formato inválido
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O email fornecido é inválido.");
        }

        [Fact]
        public void UsuarioFinal_ValidarTelefone_Obrigatorio()
        {
            var usuario = new UsuarioFinal { Telefone = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O telefone é obrigatório.");
        }

        
        [Fact]
        public void UsuarioFinal_ValidarDDD_Obrigatorio()
        {
            var usuario = new UsuarioFinal { DDD = null };
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O DDD é obrigatório.");
        }

        [Fact]
        public void UsuarioFinal_ValidarDDD_TamanhoInvalido()
        {
            var usuario = new UsuarioFinal { DDD = "1234" }; // Mais de 3 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O DDD deve ter 2 ou 3 dígitos.");
        }

        
        [Fact]
        public void UsuarioFinal_ValidarPreferencias01_TamanhoMaximo()
        {
            var usuario = new UsuarioFinal { Preferencias01 = new string('A', 101) }; // Mais de 100 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A preferência não pode exceder 100 caracteres.");
        }

        [Fact]
        public void UsuarioFinal_ValidarPreferencias02_TamanhoMaximo()
        {
            var usuario = new UsuarioFinal { Preferencias02 = new string('A', 101) }; // Mais de 100 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A preferência não pode exceder 100 caracteres.");
        }

        [Fact]
        public void UsuarioFinal_ValidarPreferencias03_TamanhoMaximo()
        {
            var usuario = new UsuarioFinal { Preferencias03 = new string('A', 101) }; // Mais de 100 caracteres
            var validationResults = ValidateModel(usuario);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A preferência não pode exceder 100 caracteres.");
        }

        private IList<ValidationResult> ValidateModel(UsuarioFinal usuario)
        {
            var context = new ValidationContext(usuario);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(usuario, context, results, true);
            return results;
        }
    }

}
