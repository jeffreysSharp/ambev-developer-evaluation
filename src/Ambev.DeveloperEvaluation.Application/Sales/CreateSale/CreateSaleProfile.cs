using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.SalesApi.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<Sale, CreateSaleResult>();
    }
}
