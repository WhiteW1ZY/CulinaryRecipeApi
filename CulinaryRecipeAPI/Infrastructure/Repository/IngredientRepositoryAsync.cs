using CulinaryRecipeAPI.Database;
using CulinaryRecipeAPI.Domain.Models; 
using CulinaryRecipeAPI.UseCases.Repository;
using Microsoft.EntityFrameworkCore;

namespace CulinaryRecipeAPI.Infrastructure.Repository
{
    public class IngredientRepositoryAsync : IIngredientRepositoryAsync
    {
        private readonly ApplicationContext _context;
        public IngredientRepositoryAsync(ApplicationContext context)
        {
            _context = context;
        } 
        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            return await _context.Ingredients
                .Include(i => i.Recipes)
                .ToListAsync();
        }
        public async Task<Ingredient?> GetIngredientById(int ingredientId)
        {
            return await _context.Ingredients
                .Include(i => i.Recipes)
                .FirstOrDefaultAsync(i => i.Id == ingredientId);
        }
        public async Task<Ingredient?> GetIngredientByName(String ingredientName)
        {
            return await _context.Ingredients
                .Include(i => i.Recipes)
                .FirstOrDefaultAsync(i => i.Name == ingredientName);
        }
        public async Task<Ingredient> CreateIngredient(Ingredient recipe)
        {
            await _context.Ingredients.AddAsync(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }
        public async Task<Ingredient> UpdateIngredient(Ingredient ingredient, Ingredient newIngredient)
        {
            ingredient.Name = newIngredient.Name;
            await _context.SaveChangesAsync();
            return ingredient;
        }
        public async Task RemoveIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync(); 
        } 
    }
}
