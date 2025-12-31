namespace CulinaryRecipeAPI.UseCases.Dto
{
    public class RecipeDto
    { 
        public string Title { get; set; }
        public string RecipeText { get; set; }
        public int CookingTime { get; set; }  
        public int AuthorId { get; set; } 
        public List<String> CategoryNames { get; set; }
        public List<String> IngredientNames { get; set; }
    }
}
