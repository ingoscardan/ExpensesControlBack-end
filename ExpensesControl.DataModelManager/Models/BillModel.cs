namespace ExpensesControl.DataModelManager.Models;

public class BillModel : DashedNamePropertyInModel
{
    public string Status { get; set; } = null!;
    public decimal Balance { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public ICollection<MovementModel> Movements { get; set; }
}