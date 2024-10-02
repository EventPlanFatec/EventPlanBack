using EventPlanApp.Domain.Entities;
using FluentValidation;
using EventPlanApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Validation
{
    public class UsuarioAdmValidator : AbstractValidator<UsuarioAdm>
    {
        public UsuarioAdmValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail deve ser válido.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.");

            RuleFor(x => x.NomeUsuario)
                .NotEmpty().WithMessage("O nome de usuário é obrigatório.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve ter 10 ou 11 dígitos.");
        }
    }
}
