using CulinaryRecipeAPI.Domain.Models;

namespace CulinaryRecipeAPI.UseCases.Classes.Searchers.RecipeSearcher
{
    public interface IRecipeSearcher
    {
        public Task<Recipe> SearchByIdAsync(int recipeId);
    }
}
