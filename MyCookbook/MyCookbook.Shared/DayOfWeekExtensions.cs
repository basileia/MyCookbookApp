namespace MyCookbook.Shared
{
    public static class DayOfWeekExtensions
    {
        public static readonly Dictionary<DayOfWeek, string> CzechNames = new()
        {
            { DayOfWeek.Monday, "Pondělí" },
            { DayOfWeek.Tuesday, "Úterý" },
            { DayOfWeek.Wednesday, "Středa" },
            { DayOfWeek.Thursday, "Čtvrtek" },
            { DayOfWeek.Friday, "Pátek" },
            { DayOfWeek.Saturday, "Sobota" },
            { DayOfWeek.Sunday, "Neděle" }
        };
    }
}
