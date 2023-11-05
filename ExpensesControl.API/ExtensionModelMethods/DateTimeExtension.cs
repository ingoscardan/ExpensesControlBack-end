namespace ExpensesControl.API.ExtensionModelMethods;

public static class DateTimeExtension
{
    public static DateTime EndOfTheDayDateTime(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
    }

    public static DateTime StartOfTheDayDateTime(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
    }
}