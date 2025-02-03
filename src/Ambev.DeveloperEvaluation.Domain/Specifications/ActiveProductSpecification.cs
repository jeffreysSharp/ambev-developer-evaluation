using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ActiveProductSpecification : ISpecification<Product>
{
    public bool IsSatisfiedBy(Product product)
    {
        return product.Status == Status.Active;
    }
}
