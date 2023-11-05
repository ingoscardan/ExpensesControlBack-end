using ExpensesControl.API.Models;

namespace ExpensesControl.API.Services;

public interface ICreditBucketService : IBucketService<CreditBucketModel>
{
    CreditBucketModel? CreateBucket(CreditBucketModel creditBucket);
    CreditBucketModel UpdateBucket(CreditBucketModel creditBucket);
    void DeleteBucket(CreditBucketModel creditBucket);
    DateTime GetNextPayment(CreditBucketModel creditBucket, DateTime date);
    decimal GetAvailable(CreditBucketModel creditBucket);
    (DateTime startDate, DateTime endDate) GetPeriod(CreditBucketModel creditBucket, DateTime date);
}