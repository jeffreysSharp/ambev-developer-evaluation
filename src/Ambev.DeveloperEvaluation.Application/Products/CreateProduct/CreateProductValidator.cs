using Ambev.SalesApi.Application.Products.CreateProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Name).NotEmpty().Length(3, 50);
        RuleFor(product => product.Description).NotEmpty().Length(3, 100);
        RuleFor(product => product.Image).NotEmpty();
    }
}