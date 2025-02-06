using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");

        RuleFor(customer => customer.Email)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Email must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Email cannot be longer than 50 characters.");

        RuleFor(customer => customer.Phone)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Phone must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Phone cannot be longer than 50 characters.");

        RuleFor(customer => customer.SocialNumber)
                .NotEmpty()
                .MinimumLength(3).WithMessage("SocialNumber must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("SocialNumber cannot be longer than 50 characters.");

        RuleFor(customer => customer.Status)
                .NotEqual(Status.Unknown)
                .WithMessage("Customer status cannot be Unknown.");

    }
}
