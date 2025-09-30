namespace MyCookbook.Data.Models
{
    public class MealPlanRecipe
    {
        public int MealPlanDayId { get; set; }
        public MealPlanDay MealPlanDay { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
