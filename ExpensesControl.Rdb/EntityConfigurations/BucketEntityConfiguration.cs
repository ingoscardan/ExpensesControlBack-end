using ExpensesControl.Rdb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesControl.Rdb.EntityConfigurations;

public class BucketEntityConfiguration : IEntityTypeConfiguration<BucketEntity>
{
    public void Configure(EntityTypeBuilder<BucketEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.DashedName);
    }
}