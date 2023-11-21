namespace ExpensesControl.Rdb.Entities;

public class BillEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string DashedName { get; set; } = null!;
    public int DueDate { get; set; }
    public string Status { get; set; }  = null!;
    public decimal Amount { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public bool Active { get; set; }
}
