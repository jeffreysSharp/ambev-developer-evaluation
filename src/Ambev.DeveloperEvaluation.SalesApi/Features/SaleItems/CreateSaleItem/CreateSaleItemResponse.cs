using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.SaleItems.CreateSaleItem;

public class CreateSaleItemResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double TotalSaleItemAmount { get; set; }
    public double Discount { get; set; }
    public double TotalPriceDiscount { get; set; }
    public DateTime CreatedAt { get; set; }
    public Status Status { get; set; }
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
}
