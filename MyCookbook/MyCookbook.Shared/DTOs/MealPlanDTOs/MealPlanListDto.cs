namespace MyCookbook.Shared.DTOs.MealPlanDTOs
{
    public class MealPlanListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
        public DayOfWeek StartDayOfWeek { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
