using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace MyCookbook.Data.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Název je povinný údaj")]
        public string Name { get; set; } = string.Empty;
        public string NormalizedName { get; set; } = string.Empty;

        public static string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var normalizedString = input.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().ToLowerInvariant();
        }
    }
}
