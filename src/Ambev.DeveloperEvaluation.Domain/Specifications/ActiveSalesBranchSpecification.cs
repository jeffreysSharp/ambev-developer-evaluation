using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ActiveSalesBranchSpecification : ISpecification<SalesBranch>
{
    public bool IsSatisfiedBy(SalesBranch salesBranch)
    {
        return salesBranch.Status == Status.Active;
    }
}
 