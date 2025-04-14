namespace MyCookbook.Results.Errors
{
    public static class RecipeError
    {
        public static readonly Error DuplicateName = new Error("Recipe.DuplicateName", "Recept s tímto názvem již existuje.");
        public static readonly Error InvalidCategoryIds = new Error("Recipe.InvalidCategoryIds", "Jedna nebo více zvolených kategorií neexistují");
    }
}
