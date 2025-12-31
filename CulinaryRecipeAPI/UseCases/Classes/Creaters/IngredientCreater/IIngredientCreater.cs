using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.IngredientCreater
{
    public interface IIngredientCreater
    {
        public Ingredient CreateFromDto(IngredientDto ingredientDto);
    }
}
