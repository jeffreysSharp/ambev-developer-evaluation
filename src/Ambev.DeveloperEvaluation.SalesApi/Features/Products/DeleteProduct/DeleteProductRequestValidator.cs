using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Products.DeleteProduct;

public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
{

    public DeleteProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
    }
}
