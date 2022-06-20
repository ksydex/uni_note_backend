namespace UniNote.Core.Extensions;

public static class DateTimeExtensions
{
    public static bool IsBetweenDates(this DateTime date, DateTime from, DateTime to)
        => date >= from && date < to;

    public static DateTime StartOfMonth(this DateTime dateTime)
        => new DateTime(dateTime.Year, dateTime.Month, 1).WithKind(DateTimeKind.Utc);


    public static DateTime StartOfHour(this DateTime dateTime)
        => new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0).WithKind(DateTimeKind.Utc);


    public static DateTime StartOfYear(this DateTime dateTime)
        => new DateTime(dateTime.Year, 1, 1).WithKind(DateTimeKind.Utc);

    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek = 0)
    {
        var diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }

    public static DateTime WithKind(this DateTime dateTime, DateTimeKind dateTimeKind)
        => DateTime.SpecifyKind(dateTime, dateTimeKind);
}