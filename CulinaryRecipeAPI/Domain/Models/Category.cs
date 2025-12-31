namespace CulinaryRecipeAPI.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
        private Category() { }
        public Category(String name)
        {
            Name = name; 
            Recipes = new List<Recipe>();
        }
    }
}
