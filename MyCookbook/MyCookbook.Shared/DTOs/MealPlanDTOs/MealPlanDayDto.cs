using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Shared.DTOs.MealPlanDTOs
{
    public class MealPlanDayDto
    {
        public int Id { get; set; }
        public int DayNumber { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }
        public List<MealPlanRecipeDto> Recipes { get; set; } = new();
    }
}
