using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.SalesApi.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public int SaleNumber { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public decimal Discount { get; set; }
    public DateTime DateSaleMade { get; set; }
    public bool Cancelled { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SalesBrancheId { get; set; }

    private readonly List<SaleItem> _saleItems;
    public IReadOnlyCollection<SaleItem> SaleItems => _saleItems;

    // EF Rel.
    public Customer Customer { get; private set; }
    public SalesBranch SalesBranche { get; private set; }


    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}