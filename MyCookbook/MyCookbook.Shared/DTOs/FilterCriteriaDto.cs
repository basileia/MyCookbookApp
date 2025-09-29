namespace MyCookbook.Shared.DTOs
{
    public class FilterCriteriaDto
    {
        public FilterCriteriaDto() { }
        public string? SearchText { get; set; }
        public bool? Favorites { get; set; }
        public bool? Tried { get; set; }
        public bool? Mine { get; set; }
        public string? Ingredient { get; set; }
    }
}
