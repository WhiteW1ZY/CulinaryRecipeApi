using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Repository
{
    public interface IRecipeRepositoryAsync
    {
        public Task<Recipe?> GetRecipeById(int recipeId);
        public Task<IEnumerable<Recipe>> GetAllRecipes();
        public Task<Recipe> CreateRecipe(Recipe recipe);
        public Task<Recipe> UpdateRecipe(Recipe recipe, Recipe newRecipe);
        public Task RemoveRecipe(Recipe recipe);
    }
}
