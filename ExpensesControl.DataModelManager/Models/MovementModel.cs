using ExpensesControl.DataModelManager.Enums;

namespace ExpensesControl.DataModelManager.Models;

public class MovementModel : BaseModel
{
    public decimal Amount { get; set; }
    public MovementType Type { get; set; }
}