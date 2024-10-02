using EventPlanApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Validation
{
    public class EventoValidator : AbstractValidator<Evento>
    {
        public EventoValidator()
        {
            RuleFor(e => e.NomeEvento)
                .NotEmpty().WithMessage("Nome do evento não pode ser nulo ou vazio.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição não pode ser nula ou vazia.")
                .MaximumLength(1000).WithMessage("A descrição não pode exceder 1000 caracteres.");

            RuleFor(e => e.DataInicio)
                .Must(value => value >= DateTime.Now).WithMessage("Data de início não pode ser no passado.");

            RuleFor(e => e.DataFim)
                .GreaterThan(e => e.DataInicio).WithMessage("Data de fim deve ser maior que a data de início.");

            RuleFor(e => e.HorarioInicio)
                .Must(value => value >= TimeSpan.FromHours(6) && value <= TimeSpan.FromHours(22))
                .WithMessage("Horário de início deve estar entre 06:00 e 22:00.");

            RuleFor(e => e.HorarioFim)
                .GreaterThan(e => e.HorarioInicio).WithMessage("Horário de fim deve ser maior que o horário de início.");

            RuleFor(e => e.LotacaoMaxima)
                .GreaterThanOrEqualTo(0).WithMessage("Lotação máxima não pode ser negativa.");

            RuleFor(e => e.TipoLogradouro)
                .NotEmpty().WithMessage("Tipo de logradouro não pode ser nulo ou vazio.");

            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage("Logradouro não pode ser nulo ou vazio.");

            RuleFor(e => e.NumeroCasa)
                .NotEmpty().WithMessage("Número da casa não pode ser nulo ou vazio.");

            RuleFor(e => e.Bairro)
                .NotEmpty().WithMessage("Bairro não pode ser nulo ou vazio.");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("Cidade não pode ser nula ou vazia.");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("Estado não pode ser nulo ou vazio.")
                .Length(2).WithMessage("Estado deve ter exatamente 2 caracteres.");

            RuleFor(e => e.CEP)
                .NotEmpty().WithMessage("CEP não pode ser nulo ou vazio.")
                .Matches(@"^\d{5}-?\d{3}$").WithMessage("CEP deve ser um formato válido (XXXXX-XXX).");

            RuleFor(e => e.Tipo)
                .NotEmpty().WithMessage("Tipo não pode ser nulo ou vazio.");

            RuleFor(e => e.Imagem01)
                .MaximumLength(200).WithMessage("A imagem não pode exceder 200 caracteres.");

            RuleFor(e => e.Imagem02)
                .MaximumLength(200).WithMessage("A imagem não pode exceder 200 caracteres.");

            RuleFor(e => e.Imagem03)
                .MaximumLength(200).WithMessage("A imagem não pode exceder 200 caracteres.");

            RuleFor(e => e.Video)
                .MaximumLength(200).WithMessage("O vídeo não pode exceder 200 caracteres.");

            RuleFor(e => e.Genero)
                .MaximumLength(50).WithMessage("O gênero não pode exceder 50 caracteres.");
        }
    }
}
