namespace ExpensesControl.DataModelManager.Models;

public class DashedNamePropertyInModel : BaseModel
{
    public string Name { get; set; }  = null!;
    public string DashedName { get; set; } = null!;
}