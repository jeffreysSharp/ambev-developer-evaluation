using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.SaleItems.CreateSaleItem;

public class CreateSaleItemRequest
{
    public Guid Id { get; set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public Status Status { get; set; }
    public Guid SaleId { get; private set; }
    public Guid ProductId { get; private set; }
}