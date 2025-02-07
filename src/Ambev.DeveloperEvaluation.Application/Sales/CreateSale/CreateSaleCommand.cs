using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.SalesApi.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public Guid Id { get; set; }
    public Guid SaleNumber { get; set; }
    public double TotalSaleAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Status Status { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SalesBrancheId { get; set; }
    public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public CreateSaleCommand(List<SaleItem> saleItems)
    {
        SaleItems = saleItems;
    }

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