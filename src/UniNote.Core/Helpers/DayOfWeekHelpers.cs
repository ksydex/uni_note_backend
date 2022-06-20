namespace UniNote.Core.Helpers;

public static class DayOfWeekHelpers
{
    public static List<DayOfWeek> GetWeek()
        => new()
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };
}