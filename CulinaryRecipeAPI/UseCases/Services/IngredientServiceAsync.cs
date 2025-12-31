using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.IngredientCreater;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.IngredientSearcher;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Repository;
namespace CulinaryRecipeAPI.UseCases.Services
{
    public class IngredientServiceAsync
    {
        private readonly IIngredientRepositoryAsync _ingredientRepositoryAsync; 
        private readonly IIngredientCreater _ingredientCreater;
        private readonly IIngredientSearcher _ingredientSearcher;
        public IngredientServiceAsync(
            IIngredientRepositoryAsync ingredientRepositoryAsync, 
            IIngredientCreater ingredientCreater,
            IIngredientSearcher ingredientSearcher
            )
        {
            _ingredientRepositoryAsync = ingredientRepositoryAsync;  
            _ingredientCreater = ingredientCreater;
            _ingredientSearcher = ingredientSearcher;
        }
        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            var ingredients = await _ingredientRepositoryAsync.GetAllIngredients();
            return ingredients;
        } 
        public async Task<Ingredient> GetIngredientById(int ingredientId)
        {
            var ingredient = await _ingredientSearcher.SearchByIdAsync(ingredientId);
            return ingredient;
        }
        public async Task<Ingredient> CreateIngredient(IngredientDto ingredientDto)
        {
            var ingredient = _ingredientCreater.CreateFromDto(ingredientDto);
            var createdIngredient = await _ingredientRepositoryAsync.CreateIngredient(ingredient);
            return createdIngredient;
        }
        public async Task<Ingredient> UpdateIngredient(int ingredientId, IngredientDto ingredientDto)
        {
            var newIngredient = _ingredientCreater.CreateFromDto(ingredientDto);
            var ingredient = await _ingredientSearcher.SearchByIdAsync(ingredientId);
            var updatedIngredien = await _ingredientRepositoryAsync.UpdateIngredient(ingredient, newIngredient);
            return updatedIngredien;
        }
        public async Task RemoveIngredient(int ingredientId)
        {
            var ingredient = await _ingredientSearcher.SearchByIdAsync(ingredientId);
            await _ingredientRepositoryAsync.RemoveIngredient(ingredient);
        } 
    }
}
