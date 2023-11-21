using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.API.Controllers.Buckets;

public interface IBucketController<TModel> where TModel : class
{
    IList<TModel> Get();
    TModel Get(int id);
    IList<MovementModel> GetMovements(int id);
    //IList<MovementModel> GetMovementsByBucketName(string bucketDashedName);
    IList<BillModel> GetBills(int id);
    //IList<BillModel> GetBillsByBillName(string bucketDashedName);
    TModel Create(TModel bucket);
    TModel ChangeBucketDetails(TModel bucket);
    TModel Delete(object id);
}