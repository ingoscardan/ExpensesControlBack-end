namespace ExpensesControl.API.Models;


/// <summary>
/// Abstract Class from all the models will derive
/// </summary>
public abstract class BaseModel
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public bool Active { get; set; }
}