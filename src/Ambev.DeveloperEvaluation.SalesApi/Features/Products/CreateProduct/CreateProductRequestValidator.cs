using FluentValidation;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Products.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(user => user.Name).NotEmpty().Length(3, 50);
        RuleFor(user => user.Description).NotEmpty().Length(3, 50);
        RuleFor(user => user.Image).NotEmpty().Length(3, 50);

    }
}