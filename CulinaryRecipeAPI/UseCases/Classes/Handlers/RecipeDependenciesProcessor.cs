using CulinaryRecipeAPI.Domain.Models; 
using CulinaryRecipeAPI.UseCases.Repository;

namespace CulinaryRecipeAPI.UseCases.Classes.Handlers
{
    public class RecipeDependenciesProcessor: IRecipeDependenciesProcessor
    {
        private readonly IIngredientRepositoryAsync _ingredientRepositoryAsync;
        private readonly ICategoryRepositoryAsync _categoryRepositoryAsync;
        public RecipeDependenciesProcessor(
            IIngredientRepositoryAsync ingredientRepositoryAsync, 
            ICategoryRepositoryAsync categoryRepositoryAsync
            ) 
        { 
            _ingredientRepositoryAsync = ingredientRepositoryAsync;
            _categoryRepositoryAsync = categoryRepositoryAsync;
        }
        public async Task ProcessRecipeDependenciesAsync(Recipe recipe)
        {
            var newIngredientsTasks = recipe.Ingredients.Select(async ingredient =>
            {
                var existedIngredient = await _ingredientRepositoryAsync.GetIngredientByName(ingredient.Name);
                return existedIngredient ?? await _ingredientRepositoryAsync.CreateIngredient(ingredient);
            });

            var newCategoriesTasks = recipe.Categories.Select(async category =>
            {
                var existedCategory = await _categoryRepositoryAsync.GetCategoryByName(category.Name);
                return existedCategory ?? await _categoryRepositoryAsync.CreateCategory(category);
            });

            var ingredients = await Task.WhenAll(newIngredientsTasks);
            var categories = await Task.WhenAll(newCategoriesTasks);

            recipe.Ingredients = ingredients;
            recipe.Categories = categories;
        }
    }
}
