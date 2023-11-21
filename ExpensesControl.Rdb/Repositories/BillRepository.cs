using ExpensesControl.Rdb.Entities;

namespace ExpensesControl.Rdb.Repositories;

public class BillRepository : GenericRepository<BillEntity>
{
    public BillRepository(PgSqlDbContext dbContext) : base(dbContext)
    {
    }

    public bool ExistBillWithSameName(string name)
    {
        return _dbSet.Any(b => b.DashedName.Equals(name));
    }

    public override BillEntity Insert(BillEntity entity)
    {
        if (ExistBillWithSameName(entity.DashedName))
        {
            throw new ArgumentException("Already exists a Bill with the same name");
        }
        return base.Insert(entity);
    }

    public override BillEntity Update(BillEntity entityToUpdate)
    {
        if (_dbSet.Any(b => b.DashedName.Equals(entityToUpdate.DashedName) && b.Id != entityToUpdate.Id))
        {
            throw new ArgumentException("That name can not be used cause has been taken already.");
        }
        return base.Update(entityToUpdate);
    }
}