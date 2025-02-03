using FluentValidation;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Products.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Name).NotEmpty().Length(3, 50);
        RuleFor(product => product.Description).NotEmpty().Length(3, 50);
        RuleFor(product => product.Image).NotEmpty().Length(3, 50);

    }
}