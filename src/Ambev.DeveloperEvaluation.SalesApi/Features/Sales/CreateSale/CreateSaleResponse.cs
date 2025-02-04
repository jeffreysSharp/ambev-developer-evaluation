using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Sale.CreateSale;

public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public decimal Discount { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Cancelled { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SalesBrancheId { get; set; }

    private readonly List<SaleItem> _saleItems;
    public IReadOnlyCollection<SaleItem> SaleItems => _saleItems;
}
