using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Sale.CreateSale;

public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public double TotalSaleAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public Status Status { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SalesBrancheId { get; set; }

    private readonly List<SaleItem> _saleItems;
    public IReadOnlyCollection<SaleItem> SaleItems => _saleItems;
}
