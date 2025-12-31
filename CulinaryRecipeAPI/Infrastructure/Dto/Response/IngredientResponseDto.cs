namespace CulinaryRecipeAPI.Infrastructure.Dto.Response
{
    public class IngredientResponseDto
    { 
        public int Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<int> RecipesId { get; set; }
    }
}
