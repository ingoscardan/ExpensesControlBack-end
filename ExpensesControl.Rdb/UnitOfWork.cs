using ExpensesControl.Rdb.Entities;
using ExpensesControl.Rdb.Repositories;

namespace ExpensesControl.Rdb;

public class UnitOfWork
{
    private readonly PgSqlDbContext _dbContext;
    private IGenericRepository<BucketEntity>? _bucketRepository;
    private BillRepository? _billRepository;
    private BillsMovementsRepository _billsMovementsRepository;
    
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
    
    public BillsMovementsRepository BillsMovementsRepository
    {
        get { return _billsMovementsRepository = _billsMovementsRepository ?? new BillsMovementsRepository(_dbContext); }
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}