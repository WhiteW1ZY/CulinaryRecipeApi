using CulinaryRecipeAPI.Domain.Models;

namespace CulinaryRecipeAPI.UseCases.Repository
{
    public interface ICategoryRepositoryAsync
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<Category?> GetCategoryById(int categoryId);
        public Task<Category?> GetCategoryByName(String categoryName);
        public Task<Category> CreateCategory(Category category);
        public Task<Category> UpdateCategory(Category category, Category newCategory);
        public Task RemoveCategory(Category category);
    }
}
