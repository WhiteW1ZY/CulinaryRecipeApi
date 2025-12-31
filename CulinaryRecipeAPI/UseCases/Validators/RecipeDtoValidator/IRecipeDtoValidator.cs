using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Validators.RecipeDtoValidator
{
    public interface IRecipeDtoValidator
    {
        public void Validate(RecipeDto recipeDto);
    }
}
