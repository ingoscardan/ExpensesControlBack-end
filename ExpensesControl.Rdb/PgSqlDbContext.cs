using ExpensesControl.Rdb.Entities;
using ExpensesControl.Rdb.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ExpensesControl.Rdb;

public class PgSqlDbContext : DbContext
{
    public PgSqlDbContext(DbContextOptions<PgSqlDbContext> options) : base(options)
    {
        
    }
    public DbSet<BucketEntity> Buckets { get; set; }
    public DbSet<MovementEntity> Movements { get; set; }
    public DbSet<BillEntity> Bills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new BucketEntityConfiguration().Configure(modelBuilder.Entity<BucketEntity>());
        new MovementEntityConfigurations().Configure(modelBuilder.Entity<MovementEntity>());
        new BillEntityConfiguration().Configure(modelBuilder.Entity<BillEntity>());
    }
}