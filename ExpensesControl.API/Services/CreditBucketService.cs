using AutoMapper;
using ExpensesControl.API.Models;
using ExpensesControl.Rdb;
using ExpensesControl.Rdb.Entities;

namespace ExpensesControl.API.Services;

public class CreditBucketService : ICreditBucketService
{
    private readonly IList<CreditBucketModel> _creditBucketModels;
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreditBucketService(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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
        var entities = _unitOfWork.BucketRepository.Get();
        var ans = new List<CreditBucketModel>();
        foreach (var entity in entities)
        {
            var model = _mapper.Map<CreditBucketModel>(entity);
            ans.Add(model);
        }
        return ans;
    }

    public CreditBucketModel? Get(int id)
    {
        var entity = _unitOfWork.BucketRepository.Get(b => b.Active && b.Id == id).FirstOrDefault();
        
        return _mapper.Map<CreditBucketModel>(entity);
    }

    public CreditBucketModel? CreateBucket(CreditBucketModel creditBucket)
    {
        var entity = new BucketEntity()
        {
            Active = creditBucket.Active,
            Available = creditBucket.Available,
            AmountMinimum = creditBucket.AmountMinimum,
            TotalDebt = creditBucket.TotalDebt,
            Balance = creditBucket.Balance,
            CutDate = creditBucket.CutDate,
            LastUpdatedDate = creditBucket.LastUpdatedDate,
            PaymentDaysLimit = creditBucket.PaymentDaysLimit,
            Name = creditBucket.Name,
            Id = creditBucket.Id,
            CreatedDate = creditBucket.CreateDate,
            LastPaymentDate = creditBucket.LastPayment,
            AmountNoInterest = creditBucket.AmountNoInterests,
            BucketType = BucketTypeEnum.CreditBucket
        };
        _unitOfWork.BucketRepository.Insert(entity);
        _unitOfWork.Save();
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