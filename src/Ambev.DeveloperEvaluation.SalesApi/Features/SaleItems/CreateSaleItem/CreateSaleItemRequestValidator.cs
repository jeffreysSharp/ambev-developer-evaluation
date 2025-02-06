using FluentValidation;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.SaleItems.CreateSaleItem;

public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
{
    public CreateSaleItemRequestValidator()
    {

        RuleFor(saleItem => saleItem.ProductId).NotEmpty();        
    }
}