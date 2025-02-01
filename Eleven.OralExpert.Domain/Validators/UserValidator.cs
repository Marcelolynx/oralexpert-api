using System.Data;
using Eleven.OralExpert.Domain.Entities;
using FluentValidation;

namespace Eleven.OralExpert.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Name).NotEmpty()
            .WithMessage("Nome é requerido!")
            .Length(2, 100).WithMessage("O Nome deve ter entre 2 e 100 caracteres.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email é Requerido")
            .EmailAddress().WithMessage("O Email informado é invalído.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("A Senha é requerida!")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");
    }
}