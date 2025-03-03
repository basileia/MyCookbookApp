using MyCookbook.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Validation
{
    public class NotEmptyListAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is IList<RecipeStep> list)
            {
                return list.Count > 0;
            }
            return false;
        }
    }
}
