using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(u => u.SaleNumber).IsRequired();
        builder.Property(u => u.CustomerId).IsRequired();
        builder.Property(u => u.SalesBrancheId).IsRequired();
        builder.Property(u => u.TotalSaleAmount).IsRequired();

        // 1 : 1 => Sale : Customer
        builder
        .HasOne(e => e.Customer)
        .WithOne(e => e.Sale)
        .HasForeignKey<Sale>(e => e.CustomerId)
        .IsRequired();

        // 1 : 1 => Sale : SalesBranche
        builder
        .HasOne(e => e.SalesBranche)
        .WithOne(e => e.Sale)
        .HasForeignKey<Sale>(e => e.SalesBrancheId)
        .IsRequired();


        // 1 : N => Sale : SaleItems
        builder.HasMany(c => c.SaleItems)
            .WithOne(c => c.Sale)
            .HasForeignKey(c => c.SaleId);
    }
}
