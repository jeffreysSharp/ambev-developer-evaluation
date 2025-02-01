using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SalesBrancheConfiguration : IEntityTypeConfiguration<SalesBranch>
{
    public void Configure(EntityTypeBuilder<SalesBranch> builder)
    {
        builder.ToTable("SalesBranches");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(u => u.Name).IsRequired().HasMaxLength(20);
        builder.Property(u => u.State).IsRequired().HasMaxLength(2);
    }
}
