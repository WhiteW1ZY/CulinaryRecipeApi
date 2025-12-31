using CulinaryRecipeAPI.Domain.Models; 
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Validators.CategoryDtoValidator;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.CategoryCreater
{
    public class CategoryCreater: ICategoryCreater
    {
        private readonly ICategoryDtoValidator _categoryDtoValidator;
        public CategoryCreater(ICategoryDtoValidator categoryDtoValidator)
        {
            _categoryDtoValidator = categoryDtoValidator;
        }
        public Category CreateFromDto(CategoryDto categoryDto)
        {
            _categoryDtoValidator.Validate(categoryDto);
            var category = new Category(categoryDto.Name);
            return category;
        }
    }
}