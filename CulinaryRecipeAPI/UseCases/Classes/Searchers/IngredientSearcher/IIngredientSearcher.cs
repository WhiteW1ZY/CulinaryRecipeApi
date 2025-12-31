using CulinaryRecipeAPI.Domain.Models;

namespace CulinaryRecipeAPI.UseCases.Classes.Searchers.IngredientSearcher
{
    public interface IIngredientSearcher
    {
        public Task<Ingredient> SearchByIdAsync(int ingredientId);
    }
}
