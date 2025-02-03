using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Products.ListProduct;

public class ListProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }
    public ProductStatus Status { get; set; }
}
