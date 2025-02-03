using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {

    RuleFor(product => product.Name)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");

    RuleFor(product => product.Description)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Description must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

     RuleFor(product => product.Status)
            .NotEqual(Status.Unknown)
            .WithMessage("Product status cannot be Unknown.");

    }
}
