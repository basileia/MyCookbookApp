namespace MyCookbook.Results.Errors
{
    public static class MealPlanError
    {
        public static readonly Error NotEnoughRecipes = new Error("MealPlan.NotEnoughRecipes", "Není dostatek receptů pro vytvoření jídelníčku.");
        public static readonly Error MealPlanNotFound = new Error("MealPlan.NotFound", "Jídelníček nebyl nalezen.");
    }
}
