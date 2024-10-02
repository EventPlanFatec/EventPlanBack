using EventPlanApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Validation
{
    public class OrganizacaoValidator : AbstractValidator<Organizacao>
    {
        public OrganizacaoValidator()
        {
            RuleFor(o => o.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Length(14).WithMessage("O CNPJ deve ter 14 caracteres.");

            RuleFor(o => o.TipoLogradouro)
                .NotEmpty().WithMessage("O tipo de logradouro é obrigatório.");

            RuleFor(o => o.Logradouro)
                .NotEmpty().WithMessage("O logradouro é obrigatório.");

            RuleFor(o => o.NumeroPredio)
                .NotEmpty().WithMessage("O número do prédio é obrigatório.");

            RuleFor(o => o.Bairro)
                .NotEmpty().WithMessage("O bairro é obrigatório.");

            RuleFor(o => o.Cidade)
                .NotEmpty().WithMessage("A cidade é obrigatória.");

            RuleFor(o => o.Estado)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .Length(2).WithMessage("O estado deve ter 2 caracteres.");

            RuleFor(o => o.CEP)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .Length(8).WithMessage("O CEP deve ter 8 caracteres.");

            RuleFor(o => o.NotaMedia)
                .InclusiveBetween(0, 10).WithMessage("A nota média deve estar entre 0 e 10.");
        }
    }
}
