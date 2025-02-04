namespace Ambev.DeveloperEvaluation.SalesApi.Features.SaleItems.CreateSaleItem;

public class CreateSaleItemResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalSaleItemAmount { get; set; }
    public decimal Dicount { get; set; }
    public decimal TotalPriceDiscount { get; set; }
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
}
