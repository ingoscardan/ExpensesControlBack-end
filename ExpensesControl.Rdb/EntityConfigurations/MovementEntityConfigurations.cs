using ExpensesControl.Rdb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesControl.Rdb.EntityConfigurations;

public class MovementEntityConfigurations : IEntityTypeConfiguration<MovementEntity>
{
    public void Configure(EntityTypeBuilder<MovementEntity> builder)
    {
        builder.HasKey(b => b.Id);
    }
}