using Ambev.DeveloperEvaluation.SalesApi.Features.SaleItems.CreateSaleItem;
using Ambev.SalesApi.Application.SaleItems.CreateSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.SalesApi.Mappings;

public class CreateSaleItemRequestProfile : Profile
{
    public CreateSaleItemRequestProfile()
    {
        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
    }
}