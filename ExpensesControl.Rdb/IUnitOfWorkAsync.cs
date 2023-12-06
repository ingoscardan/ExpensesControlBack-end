namespace ExpensesControl.Rdb;

public interface IUnitOfWorkAsync
{
    Task SaveAsync();
}