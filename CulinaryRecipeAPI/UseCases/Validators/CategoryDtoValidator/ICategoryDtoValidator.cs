using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Validators.CategoryDtoValidator
{
    public interface ICategoryDtoValidator
    {
        public void Validate(CategoryDto categoryDto);
    }
}
