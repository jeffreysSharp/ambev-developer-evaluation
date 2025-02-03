using Ambev.DeveloperEvaluation.SalesApi.Features.Products.CreateProduct;
using Ambev.SalesApi.Application.Products.CreateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.SalesApi.Mappings;

public class CreateProductRequestProfile : Profile
{
    public CreateProductRequestProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
    }
}