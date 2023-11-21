namespace ExpensesControl.DataModelManager.Models;

public class BillModel : BaseModel
{
    public string Name { get; set; }  = null!;
    public string DashedName { get; set; } = null!;
    public string Status { get; set; } = null!;
    public decimal Balance { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
}