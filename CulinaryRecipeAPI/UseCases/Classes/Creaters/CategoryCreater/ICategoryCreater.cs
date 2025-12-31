using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.CategoryCreater
{
    public interface ICategoryCreater
    {
        public Category CreateFromDto(CategoryDto categoryDto);
    }
}
