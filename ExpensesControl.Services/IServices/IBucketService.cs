using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.Services.IServices;

public interface IBucketService : IGenericCrudService<BucketModel>
{
    void Pay(MovementModel payment, BucketModel bucket);
    void Charge(MovementModel charge, BucketModel bucket);
}