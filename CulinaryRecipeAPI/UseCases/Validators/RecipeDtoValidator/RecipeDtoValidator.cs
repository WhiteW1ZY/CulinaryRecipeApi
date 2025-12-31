using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Exceptions;

namespace CulinaryRecipeAPI.UseCases.Validators.RecipeDtoValidator
{
    public class RecipeDtoValidator : IRecipeDtoValidator
    {
        public void Validate(RecipeDto recipeDto)
        {
            if (string.IsNullOrEmpty(recipeDto.Title))
            {
                throw new ValidationException("Recipe title cannot be empty");
            }
            else if (recipeDto.CookingTime <= 0)
            {
                throw new ValidationException("Cooking time must be positive");
            }
            else if (string.IsNullOrEmpty(recipeDto.RecipeText))
            {
                throw new ValidationException("Recipe text cannot be empty");
            }
        }
    }
}
