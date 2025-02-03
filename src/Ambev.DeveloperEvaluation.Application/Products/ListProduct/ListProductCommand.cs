using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

public record ListProductCommand : IRequest<ListProductResult>
{
    public ListProductCommand() { }
}
