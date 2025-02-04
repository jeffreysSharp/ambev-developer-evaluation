using FluentValidation;

namespace Ambev.SalesApi.Application.SaleItems.CreateSaleItem;

public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
{
    public CreateSaleItemCommandValidator()
    {
        RuleFor(sale => sale.SaleId).NotEmpty();
        RuleFor(sale => sale.ProductId).NotEmpty();
    }
}