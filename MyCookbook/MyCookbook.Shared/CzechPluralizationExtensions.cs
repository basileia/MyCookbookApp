namespace MyCookbook.Shared
{
    public static class CzechPluralizationExtensions
    {
        public static string CzechDays(this int number)
        {
            if (number == 1)
                return "den";

            if (number >= 2 && number <= 4)
                return "dny";

            return "dní";
        }
    }
}
