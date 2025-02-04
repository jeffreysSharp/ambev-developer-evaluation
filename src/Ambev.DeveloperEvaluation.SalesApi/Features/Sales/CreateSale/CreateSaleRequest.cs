﻿namespace Ambev.DeveloperEvaluation.SalesApi.Features.Sale.CreateSale;

public class CreateSaleRequest
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public double TotalSaleAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Cancelled { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SalesBrancheId { get; set; }

}