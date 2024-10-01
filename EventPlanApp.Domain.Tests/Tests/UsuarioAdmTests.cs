using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Tests.Tests
{
    public class UsuarioAdmTests
    {
        [Fact]
        public void UsuarioAdm_ValidarEmail_Obrigatorio()
        {
            var usuarioAdm = new UsuarioAdm { Email = null };
            var validationResults = ValidateModel(usuarioAdm);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O email é obrigatório.");
        }

        [Fact]
        public void UsuarioAdm_ValidarEmail_FormatoInvalido()
        {
            var usuarioAdm = new UsuarioAdm { Email = "emailinvalido" };
            var validationResults = ValidateModel(usuarioAdm);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O email fornecido é inválido.");
        }

        [Fact]
        public void UsuarioAdm_ValidarSenha_Obrigatoria()
        {
            var usuarioAdm = new UsuarioAdm { Senha = null };
            var validationResults = ValidateModel(usuarioAdm);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A senha é obrigatória.");
        }

        [Fact]
        public void UsuarioAdm_ValidarSenha_TamanhoMinimo()
        {
            var usuarioAdm = new UsuarioAdm { Senha = "123" }; // Menos de 6 caracteres
            var validationResults = ValidateModel(usuarioAdm);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A senha deve ter entre 6 e 100 caracteres.");
        }

        [Fact]
        public void UsuarioAdm_ValidarSenha_TamanhoMaximo()
        {
            var usuarioAdm = new UsuarioAdm { Senha = new string('A', 101) }; // Mais de 100 caracteres
            var validationResults = ValidateModel(usuarioAdm);
            Assert.Contains(validationResults, v => v.ErrorMessage == "A senha deve ter entre 6 e 100 caracteres.");
        }

        [Fact]
        public void UsuarioAdm_ValidarNomeUsuario_Obrigatorio()
        {
            var usuarioAdm = new UsuarioAdm { NomeUsuario = null };
            var validationResults = ValidateModel(usuarioAdm);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O nome de usuário é obrigatório.");
        }

        [Fact]
        public void UsuarioAdm_ValidarNomeUsuario_TamanhoMaximo()
        {
            var usuarioAdm = new UsuarioAdm { NomeUsuario = new string('A', 51) }; // Mais de 50 caracteres
            var validationResults = ValidateModel(usuarioAdm);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O nome de usuário não pode exceder 50 caracteres.");
        }

        [Fact]
        public void UsuarioAdm_ValidarTelefone_Obrigatorio()
        {
            var usuarioAdm = new UsuarioAdm { Telefone = null };
            var validationResults = ValidateModel(usuarioAdm);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O telefone é obrigatório.");
        }

        [Fact]
        public void UsuarioAdm_ValidarTelefone_FormatoInvalido()
        {
            var usuarioAdm = new UsuarioAdm { Telefone = "telefoneinvalido" };
            var validationResults = ValidateModel(usuarioAdm);
            Assert.Contains(validationResults, v => v.ErrorMessage == "O telefone fornecido é inválido.");
        }

        private List<ValidationResult> ValidateModel(UsuarioAdm usuarioAdm)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(usuarioAdm, null, null);
            Validator.TryValidateObject(usuarioAdm, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
