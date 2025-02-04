﻿using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.SalesApi.Application.SaleItems.CreateSaleItem;

public class CreateSaleItemProfile : Profile
{
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemCommand, SaleItem>();
        CreateMap<SaleItem, CreateSaleItemResult>();
    }
}
