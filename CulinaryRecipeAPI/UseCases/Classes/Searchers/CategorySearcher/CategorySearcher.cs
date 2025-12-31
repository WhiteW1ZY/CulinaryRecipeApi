using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.SearchType; 
using CulinaryRecipeAPI.UseCases.Repository;

namespace CulinaryRecipeAPI.UseCases.Classes.Searchers.CategorySearcher
{
    public class CategorySearcher : ICategorySearcher
    {
        private ICategoryRepositoryAsync _categoryRepositoryAsync;
        private ITypeSearcher _typeSearcher;
        public CategorySearcher(
            ICategoryRepositoryAsync categoryRepositoryAsync,
            ITypeSearcher typeSearcher
            )
        {
            _categoryRepositoryAsync = categoryRepositoryAsync;
            _typeSearcher = typeSearcher;
        }
        public async Task<Category> SearchByIdAsync(int categoryId) =>
            await _typeSearcher.Search<Category>(
                () => _categoryRepositoryAsync.GetCategoryById(categoryId),
                $"Category with id {categoryId} not found"
            ); 
    }
}
