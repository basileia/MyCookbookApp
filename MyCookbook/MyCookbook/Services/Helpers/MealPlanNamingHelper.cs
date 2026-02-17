using System.Text.RegularExpressions;

namespace MyCookbook.Services.Helpers
{
    public static class MealPlanNamingHelper
    {
        private static readonly Regex CopySuffixRegex =
            new Regex(@"^(.*?) \(kopie(?: (\d+))?\)$", RegexOptions.Compiled);

        private static string GetBaseName(string name)
        {
            var match = CopySuffixRegex.Match(name);
            return match.Success ? match.Groups[1].Value : name;
        }

        public static string GetNextCopyName(string originalName, List<string> existingNames)
        {
            string baseName = GetBaseName(originalName);

            var usedNumbers = new HashSet<int>();
            bool plainCopyExists = false;

            foreach (var name in existingNames)
            {
                var match = CopySuffixRegex.Match(name);
                if (!match.Success) continue;
                if (match.Groups[1].Value != baseName) continue;

                if (match.Groups[2].Success)
                    usedNumbers.Add(int.Parse(match.Groups[2].Value)); 
                else
                    plainCopyExists = true;
            }

            if (!plainCopyExists && usedNumbers.Count == 0)
                return $"{baseName} (kopie)";

            int next = 1;
            while (usedNumbers.Contains(next)) next++;
            return $"{baseName} (kopie {next})";
        }
    }
}
