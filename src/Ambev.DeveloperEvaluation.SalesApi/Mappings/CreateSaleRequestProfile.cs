using Ambev.DeveloperEvaluation.SalesApi.Features.Sale.CreateSale;
using Ambev.SalesApi.Application.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.SalesApi.Mappings;

public class CreateSaleRequestProfile : Profile
{
    public CreateSaleRequestProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
    }
}