using CulinaryRecipeAPI.Database;
using CulinaryRecipeAPI.Domain.Models; 
using CulinaryRecipeAPI.UseCases.Repository;
using Microsoft.EntityFrameworkCore;

namespace CulinaryRecipeAPI.Infrastructure.Repository
{
    public class RecipeRepositoryAsync : IRecipeRepositoryAsync
    {
        private readonly ApplicationContext _context;
        public RecipeRepositoryAsync(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            return await _context.Recipes
                .Include(r => r.Author)
                .Include(r => r.Categories)
                .Include(r => r.Ingredients)
                .ToListAsync();
        }
        public async Task<Recipe?> GetRecipeById(int recipeId)
        {
            return await _context.Recipes
                .Include(r => r.Author)
                .Include(r => r.Categories)
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id  == recipeId);
        }
        public async Task<Recipe> CreateRecipe(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }
        public async Task RemoveRecipe(Recipe recipe)
        { 
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync(); 
        }
        public async Task<Recipe> UpdateRecipe(Recipe recipe, Recipe newRecipe)
        {
            recipe.Title = newRecipe.Title;
            recipe.RecipeText = newRecipe.RecipeText;
            recipe.CookingTime = newRecipe.CookingTime;
            recipe.ImagePath = newRecipe.ImagePath;
            recipe.Categories = newRecipe.Categories;
            recipe.Ingredients = newRecipe.Ingredients; 
            recipe.Author = newRecipe.Author;
            await _context.SaveChangesAsync();
            return recipe;
        }  
    }
}
