using ExpensesControl.Rdb.Entities;
using ExpensesControl.Rdb.Repositories;

namespace ExpensesControl.Rdb;

public class UnitOfWork
{
    private PgSqlDbContext _dbContext;
    private IGenericRepository<BucketEntity>? _bucketRepository;
    private BillRepository? _billRepository;
    
    public UnitOfWork(PgSqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IGenericRepository<BucketEntity> BucketsRepository
    {
        get { return _bucketRepository = _bucketRepository ?? new BucketRepository(_dbContext); }
    }
    
    public BillRepository BillsRepository
    {
        get { return _billRepository = _billRepository ?? new BillRepository(_dbContext); }
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}