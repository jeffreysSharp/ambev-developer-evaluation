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
        builder.Property(u => u.TotalSaleAmount).IsRequired();

        builder.Property(u => u.CustomerId).IsRequired();
        builder.Property(u => u.SalesBrancheId).IsRequired();

        // 1 : N => Sale : SaleItems
        builder.HasMany(c => c.SaleItems)
                .WithOne(c => c.Sale)
                .HasForeignKey(c => c.SaleId);
    }
}
