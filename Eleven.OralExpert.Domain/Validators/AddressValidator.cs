using Eleven.OralExpert.Domain.Entities;
using FluentValidation;

namespace Eleven.OralExpert.Domain.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage("Rua não pode ser vazia.")
            .MaximumLength(150).WithMessage("Rua deve ter no máximo 150 caracteres.");

        RuleFor(a => a.Neighborhood)
            .NotEmpty().WithMessage("Bairro não pode ser vazio.")
            .MaximumLength(100).WithMessage("Bairro deve ter no máximo 100 caracteres.");

        RuleFor(a => a.City)
            .NotEmpty().WithMessage("Cidade não pode ser vazia.")
            .MaximumLength(100).WithMessage("Cidade deve ter no máximo 100 caracteres.");

        RuleFor(a => a.ZipCode)
            .NotEmpty().WithMessage("CEP não pode ser vazio.")
            .Matches(@"^\d{5}-\d{3}$").WithMessage("CEP inválido, formato esperado: 12345-678");

        RuleFor(a => a.State)
            .NotEmpty().WithMessage("Estado não pode ser vazio.")
            .MaximumLength(50).WithMessage("Estado deve ter no máximo 50 caracteres.");
    }
}