namespace MyCookbook.Shared.DTOs.MealPlanDTOs
{
    public class MealPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int Days { get; set; }
    }
}
