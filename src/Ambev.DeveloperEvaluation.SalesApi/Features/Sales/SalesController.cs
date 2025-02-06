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
            foreach (var saleItem in request.SaleItems)
            {   var saleItemRequest = new CreateSaleItemRequest();
                saleItemRequest.SaleId = response.Id;
                saleItemRequest.ProductId = saleItem.ProductId;
                saleItemRequest.Quantity = saleItem.Quantity;
                saleItemRequest.Price = saleItem.Price;
                saleItemRequest.TotalSaleItemAmount = saleItem.TotalSaleItemAmount;
                saleItemRequest.Discount = saleItem.Discount;
                saleItemRequest.TotalPriceDiscount = saleItem.TotalPriceDiscount;
                saleItemRequest.UpdatedAt = saleItem.UpdatedAt;
                saleItemRequest.Status = saleItem.Status;                

                var commandSaleImtems = _mapper.Map<CreateSaleItemCommand>(saleItemRequest);
                var responseSaleItems = await _mediator.Send(commandSaleImtems, cancellationToken);
            }          
         }

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }
}
