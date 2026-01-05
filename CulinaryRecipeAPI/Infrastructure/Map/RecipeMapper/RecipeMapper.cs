using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.Infrastructure.Dto.Response;

namespace CulinaryRecipeAPI.Infrastructure.Map.RecipeMapper
{
    public class RecipeMapper : IRecipeMapper
    { 
        public RecipeResponseDto ToRecipeResponseDto(Recipe recipe) =>
            new RecipeResponseDto
            {
                Id = recipe.Id,
                Title = recipe.Title,
                RecipeText = recipe.RecipeText,
                ImagePath = recipe.ImagePath,
                CookingTime = recipe.CookingTime,
                CreatingDate = recipe.CreatingDate,
                AuthorId = recipe.Author?.Id,
                Categories = [..recipe.Categories.Select(c => c.Name)],
                Ingredients = [..recipe.Ingredients.Select(c => c.Name)]
            };
        public IEnumerable<RecipeResponseDto> ToIEnumerableRecipeResonseDto(IEnumerable<Recipe> recipes) =>
            recipes.Select(ToRecipeResponseDto);
    }
}
