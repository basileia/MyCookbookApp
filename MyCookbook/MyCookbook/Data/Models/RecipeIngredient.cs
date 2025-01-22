//using MyCookbook.Data.Models;
//using System.ComponentModel.DataAnnotations;

//public class RecipeIngredient
//    {
//        public int RecipeId { get; set; }
//        public Recipe Recipe { get; set; } // navigation property - to not look after accoording to RecipeId

//        public int IngredientId { get; set; }
//        public Ingredient Ingredient { get; set; }

//        [Range(0.01, double.MaxValue, ErrorMessage = "Množství musí být větší než nula.")]
//        public double Quantity { get; set; }

//        [Required(ErrorMessage = "Jednotka je povinný údaj")]
//        public string Unit { get; set; }
//    }


