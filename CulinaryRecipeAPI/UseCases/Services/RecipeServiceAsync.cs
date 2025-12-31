using CulinaryRecipeAPI.Domain.Models; 
using CulinaryRecipeAPI.UseCases.Classes.Creaters.RecipeCreater;
using CulinaryRecipeAPI.UseCases.Classes.Handlers;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.RecipeSearcher;
using CulinaryRecipeAPI.UseCases.Dto; 
using CulinaryRecipeAPI.UseCases.Repository; 

namespace CulinaryRecipeAPI.UseCases.Services
{
    public class RecipeServiceAsync
    { 
        private readonly IRecipeRepositoryAsync _recipeRepositoryAsync;
        private readonly IRecipeDependenciesProcessor _recipeDependenciesProcessor;
        private readonly IRecipeCreater _recipeCreater;
        private readonly IRecipeSearcher _recipeSearcher;
        public RecipeServiceAsync( 
            IRecipeRepositoryAsync recipeRepositoryAsync,  
            IRecipeDependenciesProcessor recipeDependenciesProcessor,
            IRecipeCreater recipeCreater,
            IRecipeSearcher recipeSearcher
            ) 
        { 
            _recipeRepositoryAsync = recipeRepositoryAsync;  
            _recipeDependenciesProcessor = recipeDependenciesProcessor;
            _recipeCreater = recipeCreater;
            _recipeSearcher = recipeSearcher;
        }
        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            var recipes = await _recipeRepositoryAsync.GetAllRecipes();
            return recipes;
        }
        public async Task<Recipe> GetRecipeById(int recipeId)
        {
            var recipe = await _recipeSearcher.SearchByIdAsync(recipeId);
            return recipe;
        } 
        public async Task<Recipe> CreateRecipe(RecipeDto recipeDto)
        {
            var recipe = await _recipeCreater.CreateFromDtoAsync(recipeDto); 
            await _recipeDependenciesProcessor.ProcessRecipeDependenciesAsync(recipe);
            var createdRecipe = await _recipeRepositoryAsync.CreateRecipe(recipe); 
            return createdRecipe;
        }
        public async Task<Recipe> UpdateRecipe(int recipeId, RecipeDto newRecipeDto)
        {
            var recipe = await _recipeSearcher.SearchByIdAsync(recipeId);
            var newRecipe = await _recipeCreater.CreateFromDtoAsync(newRecipeDto);
            await _recipeDependenciesProcessor.ProcessRecipeDependenciesAsync(newRecipe);
            var updatedRecipe = await _recipeRepositoryAsync.UpdateRecipe(recipe, newRecipe);
            return updatedRecipe;
        }
        public async Task RemoveRecipeById(int recipeId)
        {
            var recipe = await _recipeSearcher.SearchByIdAsync(recipeId);
            await _recipeRepositoryAsync.RemoveRecipe(recipe);
        }   
    }
}
