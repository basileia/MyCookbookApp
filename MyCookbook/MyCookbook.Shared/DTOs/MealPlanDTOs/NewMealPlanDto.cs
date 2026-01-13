using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Shared.DTOs.MealPlanDTOs
{
    public class NewMealPlanDto
    {
        [Required(ErrorMessage = "Název jídelníčku je povinný.")]
        [StringLength(50, ErrorMessage = "Název nesmí být delší než 50 znaků.")]
        public string Name { get; set; } = string.Empty;
        [Range(1, 7, ErrorMessage = "Počet dní musí být mezi 1 a 7.")]
        public int Days { get; set; } = 5;
        public DayOfWeek StartDayOfWeek { get; set; } = DayOfWeek.Monday;
        public bool FilterMine { get; set; }
        public bool FilterTried { get; set; }
        public bool FilterFavorites { get; set; }
    }
}
