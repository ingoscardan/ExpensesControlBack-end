using ExpensesControl.API.Models;
using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.API.ExtensionModelMethods;

public static class CreditBucketModelExtensions
{
    public static DateTime GetNextPaymentDueDate(this CreditBucketModel bucketModel)
    {
        var currDate = DateTime.Now;
        if (bucketModel.CutDate == 0)
        {
            throw new Exception("A cut date should be given for a creditBucket");
        }
        
        var(currentYear, currentMont) = (currDate.Year, currDate.Month);
        var dateOnCutDate = new DateTime(currentYear, currentMont, bucketModel.CutDate).EndOfTheDayDateTime();
        return currDate > dateOnCutDate ? 
            dateOnCutDate.AddMonths(-1).AddDays(bucketModel.PaymentDaysLimit) : 
            dateOnCutDate.AddDays(bucketModel.PaymentDaysLimit);
    }
}