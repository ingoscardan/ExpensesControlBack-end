using ExpensesControl.Rdb.Entities;

namespace ExpensesControl.Rdb.Repositories;

public class BucketRepository : GenericRepository<BucketEntity>
{
    public BucketRepository(PgSqlDbContext dbContext) : base(dbContext)
    {
    }

    public override BucketEntity Insert(BucketEntity entity)
    {
        var dbEntity = Get(b => b.DashedName == entity.DashedName);
        if (dbEntity.Any())
        {
            throw new Exception("Already exists a Bucket with the same name");
        }

        if (entity.Available < 0)
        {
            throw new Exception("The available amount should be 0 or more but not less than 0");
        }

        if (entity.LastPaymentDate > DateTime.Now)
        {
            throw new Exception("The last payment date can't be in the future");
        }

        if (entity.CutDate is < 0 or > 31)
        {
            throw new Exception("The cut date should be between the range 0 to 31");
        }

        return base.Insert(entity);
    }
}