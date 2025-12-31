using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Exceptions;

namespace CulinaryRecipeAPI.UseCases.Validators.IngredientDtoValidator
{
    public class IngredientDtoValidator : IIngredientDtoValidator
    { 
        public void Validate(IngredientDto ingredientDto)
        {
            if (String.IsNullOrEmpty(ingredientDto.Name))
            {
                throw new ValidationException("Ingredient name cannot be empty"); 
            }
        }
    }
}
