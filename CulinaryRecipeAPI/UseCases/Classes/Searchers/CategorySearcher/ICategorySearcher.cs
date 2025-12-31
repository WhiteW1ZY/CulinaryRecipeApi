using CulinaryRecipeAPI.Domain.Models;

namespace CulinaryRecipeAPI.UseCases.Classes.Searchers.CategorySearcher
{
    public interface ICategorySearcher
    {
        public Task<Category> SearchByIdAsync(int categoryId);
    }
}
