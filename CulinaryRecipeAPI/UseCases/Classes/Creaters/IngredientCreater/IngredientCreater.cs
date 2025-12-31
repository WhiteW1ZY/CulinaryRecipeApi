using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Validators.IngredientDtoValidator;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.IngredientCreater
{
    public class IngredientCreater: IIngredientCreater
    {
        private readonly IIngredientDtoValidator _ingredientDtoValidator;
        public IngredientCreater(IIngredientDtoValidator ingredientDtoValidator)
        {
            _ingredientDtoValidator = ingredientDtoValidator;
        }
        public Ingredient CreateFromDto(IngredientDto ingredientDto)
        {
            _ingredientDtoValidator.Validate(ingredientDto);
            var ingredient = new Ingredient(ingredientDto.Name);
            return ingredient;
        }
    }
}
