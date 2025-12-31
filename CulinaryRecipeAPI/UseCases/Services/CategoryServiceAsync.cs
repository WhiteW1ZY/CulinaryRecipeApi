using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.CategoryCreater;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.CategorySearcher;
using CulinaryRecipeAPI.UseCases.Dto; 
using CulinaryRecipeAPI.UseCases.Repository;

namespace CulinaryRecipeAPI.UseCases.Services
{
    public class CategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync _categoryRepositoryAsync;
        private readonly ICategoryCreater _categoryCreater;
        private readonly ICategorySearcher _categorySearcher;
        public CategoryServiceAsync(
            ICategoryRepositoryAsync categoryRepositoryAsync,
            ICategoryCreater categoryCreater,
            ICategorySearcher categorySearcher
            )
        {
            _categoryRepositoryAsync = categoryRepositoryAsync;
            _categoryCreater = categoryCreater;
            _categorySearcher = categorySearcher;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await _categoryRepositoryAsync.GetAllCategories();
            return categories;
        }
        public async Task<Category> GetCategoryById(int categoryId)
        {
            var category = await _categorySearcher.SearchByIdAsync(categoryId);
            return category;
        }
        public async Task<Category> CreateCategory(CategoryDto categoryDto)
        {
            var category = _categoryCreater.CreateFromDto(categoryDto);
            var createdCategory = await _categoryRepositoryAsync.CreateCategory(category);
            return createdCategory;
        }
        public async Task<Category> UpdateCategory(int categoryId, CategoryDto categoryDto)
        {
            var newCategory = _categoryCreater.CreateFromDto(categoryDto);
            var category = await _categorySearcher.SearchByIdAsync(categoryId);
            var updatedCategory = await _categoryRepositoryAsync.UpdateCategory(category, newCategory);
            return updatedCategory;
        }
        public async Task RemoveCategory(int categoryId)
        {
            var category = await _categorySearcher.SearchByIdAsync(categoryId); 
            await _categoryRepositoryAsync.RemoveCategory(category);
        }
    }
}
