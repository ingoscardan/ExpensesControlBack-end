namespace ExpensesControl.DataModelManager.Models;

public class BucketModel : BaseModel
{
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public int CutDate { get; set; }
    public decimal Available { get; set; }
    public DateTime LastMovementDate { get; set; }
}