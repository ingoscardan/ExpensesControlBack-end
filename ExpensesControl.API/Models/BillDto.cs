namespace ExpensesControl.API.Models;

public class BillDto
{
    public string Name { get; set; }  = null!;
    public decimal Balance { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
}