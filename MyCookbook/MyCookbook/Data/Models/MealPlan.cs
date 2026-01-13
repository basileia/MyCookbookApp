namespace MyCookbook.Data.Models
{
    public class MealPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DayOfWeek StartDayOfWeek { get; set; }
        public int Days { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<MealPlanDay> DaysPlan { get; set; }
    }
}
