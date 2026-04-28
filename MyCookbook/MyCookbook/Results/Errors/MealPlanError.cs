namespace MyCookbook.Results.Errors
{
    public static class MealPlanError
    {
        public static readonly Error NotEnoughRecipes = new Error("MealPlan.NotEnoughRecipes", "Není dostatek receptů pro vytvoření jídelníčku.");
        public static readonly Error MealPlanNotFound = new Error("MealPlan.NotFound", "Jídelníček nebyl nalezen.");
        public static readonly Error DuplicateName = new Error("MealPlan.DuplicateName", "Jídelníček s tímto názvem již existuje.");
    }
}
