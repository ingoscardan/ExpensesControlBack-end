namespace ExpensesControl.API.Models;

/// <summary>
/// The representation of a Credit Bucket that can be a credit card, a departmental credit or any other credit 
/// </summary>
public class CreditBucketModel : BucketModel
{
    public int PaymentDaysLimit { get; set; }
    public decimal AmountNoInterests { get; set; }
    public decimal AmountMinimum { get; set; }
    public DateTime? LastPayment { get; set; }
    public DateTime NextPaymentDueDate { get; set; }
    public decimal TotalDebt { get; set; }
}