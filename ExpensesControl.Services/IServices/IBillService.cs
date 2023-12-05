using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.Services.IServices;

public interface IBillService : IGenericCrudService<BillModel>
{
    IEnumerable<BillModel> GetBetweenDates(DateTime startDate, DateTime? endDate);
    void ChangeName(int billId, string newName);
    void ChangeAmount(int billId, decimal newAmount);
    void Pay(int billId, MovementModel payment);
}