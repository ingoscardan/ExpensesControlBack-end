using ExpensesControl.Rdb.Entities;
using ExpensesControl.Rdb.Repositories;

namespace ExpensesControl.Rdb;

public class UnitOfWork
{
    private PgSqlDbContext _dbContext;
    private IGenericRepository<BucketEntity> _bucketRepository;
    
    public UnitOfWork(PgSqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IGenericRepository<BucketEntity> BucketRepository
    {
        get { return _bucketRepository = _bucketRepository ?? new GenericRepository<BucketEntity>(_dbContext); }
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}