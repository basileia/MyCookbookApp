using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Data.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Název je povinný údaj")]
        public string Name { get; set; }
    }
}
