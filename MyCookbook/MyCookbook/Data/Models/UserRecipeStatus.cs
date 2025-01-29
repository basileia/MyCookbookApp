namespace MyCookbook.Data.Models
{
    public class UserRecipeStatus
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public bool IsTried { get; set; }
        public bool IsFavourite { get; set; }
    }
}
