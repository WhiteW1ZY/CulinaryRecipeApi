using CulinaryRecipeAPI.Domain.Models;

namespace CulinaryRecipeAPI.UseCases.Repository
{
    public interface IIngredientRepositoryAsync
    {
        public Task<IEnumerable<Ingredient>> GetAllIngredients();
        public Task<Ingredient?> GetIngredientById(int ingredientId);
        public Task<Ingredient?> GetIngredientByName(String ingredientName);
        public Task<Ingredient> CreateIngredient(Ingredient recipe);
        public Task<Ingredient> UpdateIngredient(Ingredient ingredient, Ingredient newIngredient);
        public Task RemoveIngredient(Ingredient ingredient);
    }
}
