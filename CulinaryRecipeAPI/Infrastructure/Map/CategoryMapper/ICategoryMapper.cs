using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.Infrastructure.Dto.Response;

namespace CulinaryRecipeAPI.Infrastructure.Map.CategoryMapper
{
    public interface ICategoryMapper
    {
        public CategoryResponseDto ToCategoryResponseDto(Category category);
        public IEnumerable<CategoryResponseDto> ToIEnumerableCategoryResponseDto(IEnumerable<Category> categories);
    }
}
