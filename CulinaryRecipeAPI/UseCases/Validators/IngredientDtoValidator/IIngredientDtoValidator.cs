using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Validators.IngredientDtoValidator
{
    public interface IIngredientDtoValidator
    {
        public void Validate(IngredientDto ingredientDto);
    }
}
