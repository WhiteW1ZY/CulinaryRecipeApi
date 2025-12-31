using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.Infrastructure.Dto.Response;

namespace CulinaryRecipeAPI.Infrastructure.Map.CategoryMapper
{
    public class CategoryMapper : ICategoryMapper
    {
        public CategoryResponseDto ToCategoryResponseDto(Category category) =>
            new CategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    RecipesId = [..category.Recipes.Select(r => r.Id)]
                }; 
        public IEnumerable<CategoryResponseDto> ToIEnumerableCategoryResponseDto(IEnumerable<Category> categories) =>
                 categories.Select(ToCategoryResponseDto);
        }
}
