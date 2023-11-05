using ExpensesControl.API.Models;

namespace ExpensesControl.API.Services;

public class CreditBucketService : ICreditBucketService
{
    private readonly IList<CreditBucketModel> _creditBucketModels;

    public CreditBucketService()
    {
        _creditBucketModels = new List<CreditBucketModel>()
        {
            new CreditBucketModel()
            {
                Id = 1,
                Name = "Credit Card",
                Balance = 1000,
                CutDate = 20,
                Available = 1000,
                LastMovementDate = new DateTime(2023, 9, 20),
                PaymentDaysLimit = 20,
                AmountNoInterests = 150,
                AmountMinimum = 10,
                TotalDebt = 250,
                NextPaymentDueDate = new DateTime(2023, 9, 1).AddDays(20),
                LastPayment = new DateTime(2023, 8, 21),
                Active = true,
                CreateDate = new DateTime(),
                LastUpdatedDate = new DateTime()
            },
            new CreditBucketModel()
            {
                Id = 2,
                Name = "Credit Card 1",
                Balance = 1000,
                CutDate = 20,
                Available = 1000,
                LastMovementDate = new DateTime(2023, 9, 20),
                PaymentDaysLimit = 20,
                AmountNoInterests = 150,
                AmountMinimum = 10,
                TotalDebt = 250,
                NextPaymentDueDate = new DateTime(2023, 9, 1).AddDays(20),
                LastPayment = new DateTime(2023, 8, 21),
                Active = true,
                CreateDate = new DateTime(),
                LastUpdatedDate = new DateTime()
            },new CreditBucketModel()
            {
                Id = 3,
                Name = "Credit Card 2",
                Balance = 1000,
                CutDate = 20,
                Available = 1000,
                LastMovementDate = new DateTime(2023, 9, 20),
                PaymentDaysLimit = 20,
                AmountNoInterests = 150,
                AmountMinimum = 10,
                TotalDebt = 250,
                NextPaymentDueDate = new DateTime(2023, 9, 1).AddDays(20),
                LastPayment = new DateTime(2023, 8, 21),
                Active = true,
                CreateDate = new DateTime(),
                LastUpdatedDate = new DateTime()
            }
        };
    }
    public IList<CreditBucketModel> Get()
    {
        return _creditBucketModels.Where(cb => cb.Active).ToList();
    }

    public CreditBucketModel? Get(int id)
    {
        var ans = _creditBucketModels.FirstOrDefault(cb => cb.Id == id && cb.Active); 
        return ans;
    }

    public CreditBucketModel? CreateBucket(CreditBucketModel creditBucket)
    {
        var lastBucket = _creditBucketModels.LastOrDefault();
        if (lastBucket != null)
        {
            lastBucket.Id = lastBucket.Id++;
            lastBucket.NextPaymentDueDate = lastBucket.NextPaymentDueDate.AddDays(10);
            lastBucket.LastPayment = lastBucket.LastPayment?.AddDays(10);
            lastBucket.LastMovementDate = lastBucket.LastMovementDate.AddDays(10);
            lastBucket.LastUpdatedDate = new DateTime();
            _creditBucketModels.Add(lastBucket);
            return lastBucket;
        }

        return null;
    }

    public CreditBucketModel UpdateBucket(CreditBucketModel creditBucket)
    {
        var bucket = _creditBucketModels.FirstOrDefault(cb => cb.Id == creditBucket.Id && cb.Active);
        if (bucket != null)
        {
            creditBucket.Id = bucket.Id;
            bucket = creditBucket;
        }

        return creditBucket;
    }

    public void DeleteBucket(CreditBucketModel creditBucket)
    {
        var bucket = _creditBucketModels.FirstOrDefault(cb => cb.Id == creditBucket.Id && cb.Active);
        if (bucket != null)
        {
            bucket.Active = false;
        }
    }

    public DateTime GetNextPayment(CreditBucketModel creditBucket, DateTime date)
    {
        if (creditBucket.CutDate == 0)
        {
            throw new Exception("A cut date should be given for a creditBucket");
        }
        
        var(currentYear, currentMont, currentDay) = (date.Year, date.Month, date.Day);
        var dateOnCutDate = new DateTime(currentYear, currentMont, creditBucket.CutDate);

        return dateOnCutDate.AddDays(creditBucket.PaymentDaysLimit);
    }

    public decimal GetAvailable(CreditBucketModel creditBucket)
    {
        return  creditBucket.TotalDebt - creditBucket.Balance;
    }

    public (DateTime startDate, DateTime endDate) GetPeriod(CreditBucketModel creditBucket, DateTime date)
    {
        if (creditBucket.CutDate == 0)
        {
            throw new Exception("A cut date should be given for a creditBucket");
        }
        
        var(currentYear, currentMont, currentDay) = (date.Year, date.Month, date.Day);
        var dateOnCutDate = new DateTime(currentYear, currentMont, creditBucket.CutDate);

        return date <= dateOnCutDate ? 
            (dateOnCutDate.AddMonths(-1), dateOnCutDate) : 
            (dateOnCutDate.AddDays(1), dateOnCutDate.AddMonths(1));
    }
}