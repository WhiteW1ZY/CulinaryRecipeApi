using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Exceptions;

namespace CulinaryRecipeAPI.UseCases.Validators.CategoryDtoValidator
{
    public class CategoryDtoValidator: ICategoryDtoValidator
    { 
        public void Validate(CategoryDto categoryDto)
        {
            if(String.IsNullOrEmpty(categoryDto.Name))
            {
                throw new ValidationException("Category name cannot be null");
            }
        }
    }
}
