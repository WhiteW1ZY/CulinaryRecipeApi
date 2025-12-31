using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.Infrastructure.Dto.Response;

namespace CulinaryRecipeAPI.Infrastructure.Map.RecipeMapper
{
    public interface IRecipeMapper
    {
        public RecipeResponseDto ToRecipeResponseDto(Recipe recipe);
        public IEnumerable<RecipeResponseDto> ToIEnumerableRecipeResonseDto(IEnumerable<Recipe> recipes);
    }
}
