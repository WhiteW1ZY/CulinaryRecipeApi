using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.RecipeCreater
{
    public interface IRecipeCreater
    {
        public Task<Recipe> CreateFromDtoAsync(RecipeDto recipeDto);
    }
}
