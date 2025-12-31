using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.Infrastructure.Dto.Response;

namespace CulinaryRecipeAPI.Infrastructure.Map.IngredientMapper
{
    public class IngredientMapper: IIngredientMapper
    {
        public IngredientResponseDto ToIngredientResponseDto(Ingredient ingredient) =>
            new IngredientResponseDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                RecipesId = [..ingredient.Recipes.Select(r => r.Id)]
            };
        public IEnumerable<IngredientResponseDto> ToIEnumerableIngredientResponseDto(IEnumerable<Ingredient> ingredients) =>
            ingredients.Select(ToIngredientResponseDto);
    }
}
