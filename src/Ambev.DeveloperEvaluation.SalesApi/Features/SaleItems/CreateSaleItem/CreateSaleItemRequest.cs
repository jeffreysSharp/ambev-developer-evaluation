using Ambev.DeveloperEvaluation.Domain.Enums;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.SaleItems.CreateSaleItem;

public class CreateSaleItemRequest
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double TotalSaleItemAmount { get; set; }
    public double Discount { get; set; }
    public double TotalPriceDiscount { get; set; }
    public Guid ProductId { get; set; }
    public Guid SaleId { get; set; }
}