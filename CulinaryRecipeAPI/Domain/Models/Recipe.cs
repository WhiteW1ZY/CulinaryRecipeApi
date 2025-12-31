namespace CulinaryRecipeAPI.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String RecipeText { get; set; }
        public int CookingTime { get; set; }
        public DateTime CreatingDate { get; set; }
        public User? Author { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public Recipe(String title, String recipeText, int cookingTime, User? user, IEnumerable<Category> categories, IEnumerable<Ingredient> ingredients)
        {
            this.Title = title;
            this.RecipeText = recipeText;
            this.CookingTime = cookingTime;
            this.CreatingDate = DateTime.Now;
            this.Author = user;
            this.Categories = categories.ToList();
            this.Ingredients = ingredients.ToList();
        }
        private Recipe() { }
    }
}
