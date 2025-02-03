using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.SalesApi.Application.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<Product, CreateProductResult>();
    }
}
