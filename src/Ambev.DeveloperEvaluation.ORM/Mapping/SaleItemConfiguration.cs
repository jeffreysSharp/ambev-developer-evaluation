﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(u => u.Quantity).IsRequired();
        builder.Property(u => u.Price).IsRequired();
        builder.Property(u => u.TotalSaleItemAmount).IsRequired();
        builder.Property(u => u.TotalPriceDiscount).IsRequired();        
        builder.Property(u => u.ProductId).IsRequired();
        builder.Property(u => u.SaleId).IsRequired();
    }
}
