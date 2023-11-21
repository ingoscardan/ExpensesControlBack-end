using ExpensesControl.API.Models;
using ExpensesControl.API.Services;
using ExpensesControl.DataModelManager.Models;

namespace ExpensesControl.API.HelperFunctions;

public static class BucketUtilsFunctions
{
    /// <summary>
    /// Based on a given CreditBucketModel, this function will calculate with the given date the Date for the next payment
    /// for the account
    /// </summary>
    /// <param name="creditBucket"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetNextPayment(CreditBucketModel creditBucket, DateTime date)
    {
        if (creditBucket.CutDate == 0)
        {
            throw new Exception("A cut date should be given for a creditBucket");
        }
        
        var(currentYear, currentMont, currentDay) = (date.Year, date.Month, date.Day);
        var dateOnCutDate = new DateTime(currentYear, currentMont, creditBucket.CutDate);

        if (date > dateOnCutDate)
        {
            return dateOnCutDate.AddDays(creditBucket.PaymentDaysLimit);
        }
        
        return new DateTime();
    }

    public static decimal GetAvailable(CreditBucketModel creditBucket)
    {
        return new decimal(0.0);
    }

    public static (DateTime startDate, DateTime endDate) GetPeriod(CreditBucketModel creditBucket, DateTime date)
    {
        return (new DateTime(), new DateTime());
    }
}