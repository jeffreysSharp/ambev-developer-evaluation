using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ActiveSaleItemSpecification : ISpecification<SaleItem>
{
    public bool IsSatisfiedBy(SaleItem saleItem)    
    {
        return saleItem.Status == Status.Active;
    }
}
 