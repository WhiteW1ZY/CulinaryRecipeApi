using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.SearchType; 
using CulinaryRecipeAPI.UseCases.Repository;

namespace CulinaryRecipeAPI.UseCases.Classes.Searchers.IngredientSearcher
{
    public class IngredientSearcher: IIngredientSearcher
    {
        private IIngredientRepositoryAsync _ingredientRepositoryAsync;
        private ITypeSearcher _typeSearcher;
        public IngredientSearcher(
            IIngredientRepositoryAsync ingredientRepositoryAsync,
            ITypeSearcher typeSearcher
            )
        {
            _ingredientRepositoryAsync = ingredientRepositoryAsync;
            _typeSearcher = typeSearcher;
        }
        public async Task<Ingredient> SearchByIdAsync(int ingredientId) =>
            await _typeSearcher.Search<Ingredient>(
                () => _ingredientRepositoryAsync.GetIngredientById(ingredientId),
                $"Ingredient with id {ingredientId} not found"
            ); 
    }
}
