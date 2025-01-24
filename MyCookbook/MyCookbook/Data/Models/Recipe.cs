using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Název je povinný údaj")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Počet porcí musí být větší než nula.")]
        public int NumberOfServings { get; set; }
        [Required(ErrorMessage = "Postup přípravy je povinný údaj.")]
        public string Preparation { get; set; }
        public List<Ingredient> IngredientsList { get; set; } = new List<Ingredient>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public int UserId { get; set; } //user who added the recipe
        public ApplicationUser User { get; set; }  // navigation for user (Identity)
    }
}
