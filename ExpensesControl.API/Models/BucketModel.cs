namespace ExpensesControl.API.Models;


/// <summary>
/// The general representation of a Bucket
/// From this other classes may derive
/// </summary>
public class BucketModel : BaseModel
{
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public int CutDate { get; set; }
    public decimal Available { get; set; }
    public DateTime LastMovementDate { get; set; }
}