using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.Services.IServices;

public interface IMovementService
{
    MovementModel ChargeBucket(BucketModel bucket, decimal amount, DateTime? applicationDate = null, Guid? tracker = null);
    MovementModel PayBucket(BucketModel bucket, decimal amount, DateTime? applicationDate = null, Guid? tracker = null);
    MovementModel PayBill(BillModel bill, BucketModel bucket, decimal amount, DateTime? applicationDate = null, Guid? tracker = null);
}