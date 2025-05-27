using MyCookbook.Shared.DTOs.CategoryDTOs;

namespace MyCookbook.Shared.DTOs.RecipeDTOs
{
    public class RecipeListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<string> Icons => GetCategoryIcons();

        private List<string> GetCategoryIcons()
        {
            List<string> icons = new List<string>();

            if (Categories.Any(c => c.Name == "Snídaně")) icons.Add("fa-solid fa-bread-slice");
            if (Categories.Any(c => c.Name == "Oběd")) icons.Add("fa-solid fa-utensils");
            if (Categories.Any(c => c.Name == "Večeře")) icons.Add("fa-solid fa-bowl-food");
            if (Categories.Any(c => c.Name == "Svačina")) icons.Add("fa-solid fa-mug-hot");

            return icons.Any() ? icons : new List<string> { "fa-solid fa-question" };
        }
    }
}
