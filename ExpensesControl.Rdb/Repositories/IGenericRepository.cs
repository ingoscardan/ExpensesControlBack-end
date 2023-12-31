using System.Linq.Expressions;

namespace ExpensesControl.Rdb.Repositories;

public interface IGenericRepository<TEntity> where TEntity:class
{
    IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "");

    TEntity GetById(object id);
    TEntity Insert(TEntity entity);
    void Delete(object id);
    void Delete(TEntity entityToDelete);
    TEntity Update(TEntity entityToUpdate);
}