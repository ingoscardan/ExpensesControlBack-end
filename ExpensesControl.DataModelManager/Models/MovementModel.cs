using ExpensesControl.DataModelManager.Enums;

namespace ExpensesControl.DataModelManager.Models;

public class MovementModel : BaseModel
{
    public decimal Amount { get; set; }
    public MovementType Type { get; set; }
    public DateTime ApplicationDate { get; set; }
    public Guid MovementTracker { get; set; }
    public ICollection<BillModel> BillsModel { get; set; }
}