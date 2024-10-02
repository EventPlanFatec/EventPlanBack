using EventPlanApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Validation
{
    public class IngressoValidator : AbstractValidator<Ingresso>
    {
        public IngressoValidator()
        {
            RuleFor(ingresso => ingresso.Valor)
                .GreaterThan(0).WithMessage("O valor deve ser maior que zero.");

            RuleFor(ingresso => ingresso.QRCode)
                .NotEmpty().WithMessage("O QRCode é obrigatório.");

            RuleFor(ingresso => ingresso.NomeEvento)
                .NotEmpty().WithMessage("O nome do evento é obrigatório.");

            RuleFor(ingresso => ingresso.Data)
                .GreaterThan(DateTime.Now).WithMessage("A data não pode ser no passado.");
        }
    }
}
