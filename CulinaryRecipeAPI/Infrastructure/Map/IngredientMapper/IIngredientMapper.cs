using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.Infrastructure.Dto.Response;

namespace CulinaryRecipeAPI.Infrastructure.Map.IngredientMapper
{
    public interface IIngredientMapper
    {
        public IngredientResponseDto ToIngredientResponseDto(Ingredient ingredient);
        public IEnumerable<IngredientResponseDto> ToIEnumerableIngredientResponseDto(IEnumerable<Ingredient> ingredients);
    }
}
