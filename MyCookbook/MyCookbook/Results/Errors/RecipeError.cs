namespace MyCookbook.Results.Errors
{
    public static class RecipeError
    {
        public static Error DuplicateName = new Error("Recipe.DuplicateName", "Recept s tímto názvem již existuje.");
    }
}
