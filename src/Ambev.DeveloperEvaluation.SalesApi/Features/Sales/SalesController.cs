﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.SalesApi.Common;
using Ambev.DeveloperEvaluation.SalesApi.Features.Sale.CreateSale;
using Ambev.DeveloperEvaluation.SalesApi.Features.SaleItems.CreateSaleItem;
using Ambev.SalesApi.Application.SaleItems.CreateSaleItem;
using Ambev.SalesApi.Application.Sales.CreateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Sales;

[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SalesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var commandSale = _mapper.Map<CreateSaleCommand>(request);
        var response = await _mediator.Send(commandSale, cancellationToken);

        if (response != null)
        {
            PopularSaleItems(response, request.SaleItems, cancellationToken);
        }

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }

    private async void PopularSaleItems(CreateSaleResult response, List<SaleItem> saleItems, CancellationToken cancellationToken)
    {
        
        foreach (var saleItem in saleItems)
        {
            var discount = 0;

            if (saleItem.Quantity > 4 && saleItem.Quantity <= 9)
                discount = 10;
            else if (saleItem.Quantity > 4 && saleItem.Quantity >= 9 && saleItem.Quantity <= 20)
                discount = 20;
            else if (saleItem.Quantity > 20)
            {

                BadRequest(string.Empty, new ApiResponse
                {
                    Success = false,
                    Message = "It is not possible to purchase more than 20 products"
                });

                return;
            }

            var saleItemRequest = new CreateSaleItemRequest();
            saleItemRequest.SaleId = response.Id;
            saleItemRequest.ProductId = saleItem.ProductId;
            saleItemRequest.Quantity = saleItem.Quantity;
            saleItemRequest.Price = saleItem.Price;
            saleItemRequest.TotalSaleItemAmount = saleItem.Price * saleItem.Quantity;
            saleItemRequest.Discount = discount;
            saleItemRequest.TotalPriceDiscount = saleItemRequest.TotalSaleItemAmount - ((saleItemRequest.TotalSaleItemAmount / 100) * discount);

            var commandSaleImtems = _mapper.Map<CreateSaleItemCommand>(saleItemRequest);
            var responseSaleItems = await _mediator.Send(commandSaleImtems, cancellationToken);
        }
    }
}

