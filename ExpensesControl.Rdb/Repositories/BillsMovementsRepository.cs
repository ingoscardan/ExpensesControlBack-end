using ExpensesControl.DataModelManager.Models;
using ExpensesControl.Rdb.EntitiesJoins;
using ExpensesControl.Rdb.IRepositories;

namespace ExpensesControl.Rdb.Repositories;

public class BillsMovementsRepository : GenericRepository<BillMovementEntity>, IBillsMovementsRepository
{
    public BillsMovementsRepository(PgSqlDbContext dbContext) : base(dbContext)
    {
    }
    
    public MovementModel? PayBill(BillModel model, MovementModel movement)
    {
        var paymentMovementEntity = new BillMovementEntity()
        {
            Movement = movement,
            BillsId = model.Id,
            Bill = model,
            MovementsId = movement.Id,
        };
        var res = Insert(paymentMovementEntity);
        return res?.Movement;
    }
}