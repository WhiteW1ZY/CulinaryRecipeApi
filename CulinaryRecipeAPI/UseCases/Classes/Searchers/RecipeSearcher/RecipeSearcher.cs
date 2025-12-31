using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.SearchType; 
using CulinaryRecipeAPI.UseCases.Repository;

namespace CulinaryRecipeAPI.UseCases.Classes.Searchers.RecipeSearcher
{
    public class RecipeSearcher : IRecipeSearcher
    {
        private IRecipeRepositoryAsync _recipeRepositoryAsync;
        private ITypeSearcher _typeSearcher;
        public RecipeSearcher(
            IRecipeRepositoryAsync recipeRepositoryAsync,
            ITypeSearcher typeSearcher
            )
        {
            _recipeRepositoryAsync = recipeRepositoryAsync;
            _typeSearcher = typeSearcher;
        }
        public async Task<Recipe> SearchByIdAsync(int recipeId) =>
            await _typeSearcher.Search<Recipe>(
                () => _recipeRepositoryAsync.GetRecipeById(recipeId), 
                $"Recipe with id {recipeId} not found"
            ); 
    }
}
