using EventPlanApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Validation
{
    public class UsuarioFinalValidator : AbstractValidator<UsuarioFinal>
    {
        public UsuarioFinalValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("Nome não pode ser nulo ou vazio.");

            RuleFor(u => u.Sobrenome)
                .NotEmpty().WithMessage("Sobrenome não pode ser nulo ou vazio.");

            RuleFor(u => u.TipoLogradouro)
                .NotEmpty().WithMessage("Tipo de logradouro não pode ser nulo ou vazio.");

            RuleFor(u => u.Logradouro)
                .NotEmpty().WithMessage("Logradouro não pode ser nulo ou vazio.");

            RuleFor(u => u.NumeroCasa)
                .NotEmpty().WithMessage("Número da casa não pode ser nulo ou vazio.");

            RuleFor(u => u.Bairro)
                .NotEmpty().WithMessage("Bairro não pode ser nulo ou vazio.");

            RuleFor(u => u.Cidade)
                .NotEmpty().WithMessage("Cidade não pode ser nula ou vazia.");

            RuleFor(u => u.Estado)
                .NotEmpty().WithMessage("Estado não pode ser nulo ou vazio.")
                .Length(2).WithMessage("Estado deve ter exatamente 2 caracteres.");

            RuleFor(u => u.CEP)
                .NotEmpty().WithMessage("CEP não pode ser nulo ou vazio.")
                .Matches(@"^\d{5}-?\d{3}$").WithMessage("CEP deve ser um formato válido (XXXXX-XXX).");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email não pode ser nulo ou vazio.")
                .EmailAddress().WithMessage("Email deve ser um formato válido.");

            RuleFor(u => u.Telefone)
                .NotEmpty().WithMessage("Telefone não pode ser nulo ou vazio.");

            RuleFor(u => u.DDD)
                .NotEmpty().WithMessage("DDD não pode ser nulo ou vazio.")
                .Length(2).WithMessage("DDD deve ter exatamente 2 caracteres.");

            RuleFor(u => u.DataNascimento)
                .LessThan(DateTime.Now).WithMessage("Data de nascimento não pode ser uma data futura.");

            RuleFor(u => u.Preferencias01)
                .MaximumLength(100).WithMessage("As preferências não podem exceder 100 caracteres.");

            RuleFor(u => u.Preferencias02)
                .MaximumLength(100).WithMessage("As preferências não podem exceder 100 caracteres.");

            RuleFor(u => u.Preferencias03)
                .MaximumLength(100).WithMessage("As preferências não podem exceder 100 caracteres.");
        }
    }
}
