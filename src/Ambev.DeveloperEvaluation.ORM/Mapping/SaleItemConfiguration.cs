using Ambev.DeveloperEvaluation.Domain.Entities;
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
        builder.Property(u => u.SaleId).IsRequired();
        builder.Property(u => u.ProductId).IsRequired();

        // 1 : 1 => SaleItems : Product
        builder
        .HasOne(e => e.Product)
        .WithOne(e => e.SaleItem)
        .HasForeignKey<SaleItem>(e => e.SaleId)
        .IsRequired();
    }
}
