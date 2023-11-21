using ExpensesControl.Rdb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesControl.Rdb.EntityConfigurations;

public class BillEntityConfiguration : IEntityTypeConfiguration<BillEntity>
{
    public void Configure(EntityTypeBuilder<BillEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.DashedName);
    }
}