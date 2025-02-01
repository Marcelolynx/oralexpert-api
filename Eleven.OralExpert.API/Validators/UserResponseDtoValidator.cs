using Eleven.OralExpert.API.DTOs;
using FluentValidation;

namespace Eleven.OralExpert.API.Validators;

public class UserResponseDtoValidator : AbstractValidator<UserResponseDto>
{
    public UserResponseDtoValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");
    }
} 