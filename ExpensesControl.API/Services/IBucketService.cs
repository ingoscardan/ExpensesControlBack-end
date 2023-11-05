using ExpensesControl.API.Models;

namespace ExpensesControl.API.Services;

public interface IBucketService<T> where T : class
{
    IList<T> Get();
    CreditBucketModel? Get(int id);
}