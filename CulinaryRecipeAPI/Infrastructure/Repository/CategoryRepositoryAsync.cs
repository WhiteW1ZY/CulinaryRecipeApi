using CulinaryRecipeAPI.Database;
using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Repository;
using Microsoft.EntityFrameworkCore;

namespace CulinaryRecipeAPI.Infrastructure.Repository
{
    public class CategoryRepositoryAsync: ICategoryRepositoryAsync
    {
        private readonly ApplicationContext _context;
        public CategoryRepositoryAsync(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories
                .Include(i => i.Recipes)
                .ToListAsync();
        }
        public async Task<Category?> GetCategoryById(int categoryId)
        {
            return await _context.Categories
                .Include(i => i.Recipes)
                .FirstOrDefaultAsync(i => i.Id == categoryId);
        }
        public async Task<Category?> GetCategoryByName(String categoryName)
        {
            return await _context.Categories
                .Include(i => i.Recipes)
                .FirstOrDefaultAsync(i => i.Name == categoryName);
        }
        public async Task<Category> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> UpdateCategory(Category category, Category newCategory)
        {
            category.Name = newCategory.Name;
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        } 
    }
}
