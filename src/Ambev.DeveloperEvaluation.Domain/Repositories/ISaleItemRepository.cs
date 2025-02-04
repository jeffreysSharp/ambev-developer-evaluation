using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleItemRepository
{
    Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
}

