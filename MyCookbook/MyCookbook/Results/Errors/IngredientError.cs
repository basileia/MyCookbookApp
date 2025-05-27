namespace MyCookbook.Results.Errors
{
    public static class IngredientError
    {
        public static readonly Error DuplicateName = new Error("Ingredient.DuplicateName", "Ingredience s tímto názvem již existuje.");
        public static readonly NotFoundError IngredientNotFound = new NotFoundError("Ingredient.NotFound", "Ingredience nebyla nalezena.");
        public static readonly Error InvalidQuery = new Error("Ingredient.InvalidQuery", "Hledaný výraz je neplatný. Zadejte prosím platný název ingredience.");
    }
}
