using AutoMapper;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Products.DeleteProduct;
public class DeleteProductProfile : Profile
{

    public DeleteProductProfile()
    {
        CreateMap<Guid, Application.Products.DeleteProduct.DeleteProductCommand>()
            .ConstructUsing(id => new Application.Products.DeleteProduct.DeleteProductCommand(id));
    }
}
