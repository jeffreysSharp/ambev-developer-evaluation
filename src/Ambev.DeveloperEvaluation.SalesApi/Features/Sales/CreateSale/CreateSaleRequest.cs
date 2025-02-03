using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Sale.CreateSale;

public class CreateSaleRequest
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public decimal Discount { get; set; }
    public DateTime DateSaleMade { get; set; }
    public bool Cancelled { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SalesBrancheId { get; set; }

    //private readonly List<SaleItem> _saleItems;
    //public IReadOnlyCollection<SaleItem> SaleItems => _saleItems;

    //// EF Rel.
    //public Customer Customer { get; private set; }
    //public SalesBranch SalesBranche { get; private set; }

}