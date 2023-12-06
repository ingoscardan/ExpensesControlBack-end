using ExpensesControl.DataModelManager.Models;
using ExpensesControl.Rdb.Entities;
using ExpensesControl.Rdb.Repositories;

namespace ExpensesControl.Rdb.IRepositories;

public interface IBillsMovementsRepository
{
    MovementModel? PayBill(BillModel model, MovementModel movement);
}