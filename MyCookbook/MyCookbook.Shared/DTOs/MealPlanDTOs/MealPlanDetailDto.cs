namespace MyCookbook.Shared.DTOs.MealPlanDTOs
{
    public class MealPlanDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Days { get; set; }
        public DayOfWeek StartDayOfWeek { get; set; }

        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } = string.Empty;

        public List<MealPlanDayDto> DaysPlan { get; set; } = [];
    }
}
