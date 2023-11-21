using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.Services.IServices;

public interface IBillService : IGenericCrudService<BillModel>
{
    void Pay(int billId, MovementModel payment);
}