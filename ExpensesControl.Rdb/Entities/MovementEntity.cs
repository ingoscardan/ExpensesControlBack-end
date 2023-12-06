using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.Rdb.Entities;

public class MovementEntity : MovementModel
{
    //public Guid TrackerId { get; set; }
    public List<BillEntity> Bills { get; set; } = new List<BillEntity>();
}