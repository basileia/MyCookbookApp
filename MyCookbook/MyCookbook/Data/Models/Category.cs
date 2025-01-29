﻿namespace MyCookbook.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
