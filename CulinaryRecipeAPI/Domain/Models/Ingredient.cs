namespace CulinaryRecipeAPI.Domain.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; } 
        private Ingredient() { }
        public Ingredient(String name)
        {
            Name = name;  
            Recipes = new List<Recipe>();
        }
    }
}
