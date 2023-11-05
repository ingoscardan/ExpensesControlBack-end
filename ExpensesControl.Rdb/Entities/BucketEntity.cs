namespace ExpensesControl.Rdb.Entities;

public class BucketEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public decimal Balance { get; set; }
    public int CutDate { get; set; }
    public decimal Available { get; set; }
    public DateTime LastPaymentDate { get; set; }
    public int PaymentDaysLimit { get; set; }
    public decimal AmountNoInterest { get; set; }
    public decimal AmountMinimum { get; set; }
    public decimal TotalDebt { get; set; }
    public BucketTypeEnum BucketType { get; set; }
    public bool Active { get; set; }
}