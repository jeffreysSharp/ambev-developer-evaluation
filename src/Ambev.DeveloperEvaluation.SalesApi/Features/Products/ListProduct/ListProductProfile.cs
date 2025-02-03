using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.ListProduct;
using Ambev.DeveloperEvaluation.SalesApi.Features.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Products.ListProduct;

public class ListProductProfile : Profile
{
    public ListProductProfile()
    {      
        CreateMap<ListProductRequest, ListProductCommand>();
        //CreateMap<ListProductResponse, ListProductResult>();
        //CreateMap<ListProductResult, ListProductResponse>();
    }
}
