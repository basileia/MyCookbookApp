using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Shared.DTOs.MealPlanDTOs
{
    public class RenameMealPlanDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
