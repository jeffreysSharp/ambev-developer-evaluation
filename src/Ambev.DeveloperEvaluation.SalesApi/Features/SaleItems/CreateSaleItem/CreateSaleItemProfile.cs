using Ambev.SalesApi.Application.SaleItems.CreateSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.SaleItems.CreateSaleItem;

public class CreateSaleItemProfile : Profile
{
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();
        CreateMap<CreateSaleItemResult, CreateSaleItemResponse>();
    }
}
