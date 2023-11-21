namespace ExpensesControl.Rdb.Repositories;

public abstract class DashedNamePropertyOnEntity<TEntity> : GenericRepository<TEntity> where TEntity : class
{
    protected DashedNamePropertyOnEntity(PgSqlDbContext dbContext) : base(dbContext)
    {
    }

    private bool ExistsEntityWithSameName(string name)
    {
        return true;
    }

    protected string GenerateDashedName(string name)
    {
        return name;
    }
}