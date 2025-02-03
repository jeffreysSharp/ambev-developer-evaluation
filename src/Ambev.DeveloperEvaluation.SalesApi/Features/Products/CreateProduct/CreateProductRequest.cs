﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.SalesApi.Features.Products.CreateProduct;

public class CreateProductRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Image { get; set; } = string.Empty;
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }
    public Status Status { get; set; }
    //public SaleItem SaleItem { get; private set; }
}