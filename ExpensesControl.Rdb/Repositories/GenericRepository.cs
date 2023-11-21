using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ExpensesControl.Rdb.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly PgSqlDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(PgSqlDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }
    
    public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
        string includeProperties = "")
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
                     (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        return orderBy != null ? orderBy(query).ToList() : query.ToList();
    }

    public virtual TEntity GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public virtual TEntity Insert(TEntity entity)
    {
        return _dbSet.Add(entity).Entity;
    }

    public virtual void Delete(object id)
    {
        TEntity entityToDelete = _dbSet.Find(id);
        Delete(entityToDelete);
    }

    public void Delete(TEntity entityToDelete)
    {
        if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);
    }

    public virtual TEntity Update(TEntity entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        return entityToUpdate;
    }
}