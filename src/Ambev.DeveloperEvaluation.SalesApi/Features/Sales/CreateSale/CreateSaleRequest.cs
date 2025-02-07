using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Sale.CreateSale;

public class CreateSaleRequest
{
    public Guid CustomerId { get; set; }
    public Guid SalesBrancheId { get; set; }
    public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public CreateSaleRequest() { }

    public CreateSaleRequest(List<SaleItem> saleItems)
    {
        SaleItems = saleItems;
    }
}