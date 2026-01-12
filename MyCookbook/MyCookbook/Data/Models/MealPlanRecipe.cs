namespace MyCookbook.Data.Models
{
    public class MealPlanRecipe
    {
        public int MealPlanDayId { get; set; }
        public MealPlanDay MealPlanDay { get; set; } 

        public int? RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
