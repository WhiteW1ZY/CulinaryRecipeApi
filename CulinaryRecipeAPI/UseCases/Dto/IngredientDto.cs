namespace CulinaryRecipeAPI.UseCases.Dto
{
    public class IngredientDto
    {
        public String Name { get; set; } 
        public IngredientDto(String name)
        {
            Name = name; 
        }
    }
}
