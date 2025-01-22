namespace MyCookbook.Data.Models
{
    public class Ingredient
    {
        public int Id { get; set; }       
        public string Name { get; set; }

        public Ingredient(string name)
        {
            Name = name;
        }

        public Ingredient() { }
    }
}
