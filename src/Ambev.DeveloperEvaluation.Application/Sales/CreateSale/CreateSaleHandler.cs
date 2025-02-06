using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.SalesApi.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ISaleItemRepository saleItemRepository)
    {
        _saleRepository = saleRepository;      
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);


        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingSaleId = await _saleRepository.GetBySaleIdAsync(command.Id, cancellationToken);
        if (existingSaleId != null)
            throw new InvalidOperationException($"Sale with Sale Id {command.Id} already exists");

        var existingSaleNumber = await _saleRepository.GetBySaleNumberAsync(command.SaleNumber, cancellationToken);
        if (existingSaleNumber != null)
            throw new InvalidOperationException($"Sale with Sale Number {command.SaleNumber} already exists");

        command.CreatedAt = DateTime.UtcNow;
        command.UpdatedAt = DateTime.UtcNow;
        command.Status = Status.Active;

        var sale = _mapper.Map<Sale>(command);

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
        var result = _mapper.Map<CreateSaleResult>(createdSale);

        return result;
    }
}
