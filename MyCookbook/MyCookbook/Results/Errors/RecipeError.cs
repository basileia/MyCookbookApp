namespace MyCookbook.Results.Errors
{
    public static class RecipeError
    {
        public static readonly Error DuplicateName = new Error("Recipe.DuplicateName", "Recept s tímto názvem již existuje.");
        public static readonly Error InvalidCategoryIds = new Error("Recipe.InvalidCategoryIds", "Jedna nebo více zvolených kategorií neexistují");
        public static readonly NotFoundError RecipeNotFound = new NotFoundError("Recipe.NotFound", "Recept nebyl nalezen.");
        public static readonly Error IngredientAlreadyInRecipe = new Error("Recipe.IngredientAlreadyInRecipe", "Tato surovina je již v receptu přidána.");
    }
}
