namespace MyCookbook.Data.Models
{
    public class MealPlanDay
    {
        public int Id { get; set; }
        public int DayNumber { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string? Notes { get; set; } = null;

        public int MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; }

        public ICollection<MealPlanRecipe> Recipes { get; set; }
    }
}
