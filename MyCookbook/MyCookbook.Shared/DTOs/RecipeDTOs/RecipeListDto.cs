namespace MyCookbook.Shared.DTOs.RecipeDTOs
{
    public class RecipeListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public string Icon => GetCategoryIcon();

        private string GetCategoryIcon()
        {
            if (Categories.Any(c => c.Name == "Snídaně")) return "fa-solid fa-bread-slice";
            if (Categories.Any(c => c.Name == "Oběd")) return "fa-solid fa-utensils";
            if (Categories.Any(c => c.Name == "Večeře")) return "fa-solid fa-bowl-food";
            if (Categories.Any(c => c.Name == "Svačina")) return "fa-solid fa-mug-hot";
            return "fa-solid fa-question";
        }
    }
}
