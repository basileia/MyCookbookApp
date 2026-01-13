namespace MyCookbook.Shared.DTOs.MealPlanDTOs
{
    public class MealPlanRecipeDto
    {
        public int MealPlanDayId { get; set; }
        public int? RecipeId { get; set; }
        public string? RecipeName { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
