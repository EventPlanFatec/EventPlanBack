using EventPlanApp.Domain.Entities;
using FluentValidation;

public class UserPreferencesValidator : AbstractValidator<UserPreferences>
{
    public UserPreferencesValidator()
    {
        // Validar o tipo de evento
        RuleFor(up => up.EventType)
            .NotEmpty().WithMessage("Tipo de evento é obrigatório.")
            .Length(2, 50).WithMessage("O tipo de evento deve ter entre 2 e 50 caracteres.");

        // Validar a localização
        RuleFor(up => up.Location)
            .NotEmpty().WithMessage("Localização é obrigatória.")
            .Length(2, 100).WithMessage("A localização deve ter entre 2 e 100 caracteres.");

        // Validar a faixa de preço
        RuleFor(up => up.PriceRange)
            .NotEmpty().WithMessage("Faixa de preço é obrigatória.")
            .Matches(@"^\d+\-\d+$").WithMessage("A faixa de preço deve estar no formato 'minimo-maximo'.");
    }
}
