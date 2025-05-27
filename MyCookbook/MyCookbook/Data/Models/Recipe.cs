using MyCookbook.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Název je povinný údaj")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Název musí mít 3-100 znaků")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Počet porcí je povinný údaj.")]
        [Range(1, int.MaxValue, ErrorMessage = "Počet porcí musí být větší než nula.")]
        public int NumberOfServings { get; set; }
        [NotEmptyList(ErrorMessage = "Musíš přidat alespoň jeden krok postupu.")]
        public List<RecipeStep> Steps { get; set; } = new List<RecipeStep>();
        [NotEmptyList(ErrorMessage = "Musíš přidat alespoň jednu ingredienci.")]
        public List<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public DateTime DateAdded { get; set; } = DateTime.Now;
        [Required]
        public string UserId { get; set; } //user who added the recipe
        public ApplicationUser User { get; set; }  // navigation for user (Identity)
    }
}
