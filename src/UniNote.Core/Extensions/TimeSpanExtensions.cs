namespace UniNote.Core.Extensions;

public static class TimeSpanExtensions
{
    public static TimeSpan AddIn24HoursFormat(this TimeSpan time1, TimeSpan time2)
    {
        var r = time1.Add(time2);
        var toAddDays = r.TotalHours switch
        {
            > 24 => -1,
            < 0 => 1,
            _ => 0
        };

        return r.Add(TimeSpan.FromDays(toAddDays));
    }
}