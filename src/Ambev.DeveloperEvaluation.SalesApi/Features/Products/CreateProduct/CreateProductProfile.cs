using Ambev.SalesApi.Application.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<CreateProductResult, CreateProductResponse>();
    }
}
