using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.CategoryCreater;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.ImageCreater;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.IngredientCreater; 
using CulinaryRecipeAPI.UseCases.Classes.Searchers.UserSearcher;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Validators.RecipeDtoValidator;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.RecipeCreater
{
    public class RecipeCreater : IRecipeCreater
    {
        private readonly IRecipeDtoValidator _recipeDtoValidator;
        private readonly IIngredientCreater _ingredientCreater;
        private readonly ICategoryCreater _categoryCreater;
        private readonly IUserSearcher _userSearcher;
        private readonly IImageCreater _imageCreater;
        public RecipeCreater(
            IRecipeDtoValidator recipeDtoValidator, 
            IIngredientCreater ingredientCreater,
            ICategoryCreater categoryCreater,
            IUserSearcher userSearcher,
            IImageCreater imageCreater
            )
        {
            _recipeDtoValidator = recipeDtoValidator;
            _ingredientCreater = ingredientCreater;
            _categoryCreater = categoryCreater;
            _userSearcher = userSearcher;
            _imageCreater = imageCreater;
        }
        public async Task<Recipe> CreateFromDtoAsync(RecipeDto recipeDto)
        {
            _recipeDtoValidator.Validate(recipeDto);

            var ingredientList = recipeDto.IngredientNames
                .Select(i => _ingredientCreater.CreateFromDto(new IngredientDto(i)));

            var categoryList = recipeDto.CategoryNames
                .Select(i => _categoryCreater.CreateFromDto(new CategoryDto(i)));

            var user = await _userSearcher.SearchByIdAsync(recipeDto.AuthorId);

            String? imagePath = null;

            if(recipeDto.Image is not null)
            {
                imagePath = await _imageCreater.CreateImageByFormFileAsync(recipeDto.Image!);
            }

            return new Recipe(recipeDto.Title, recipeDto.RecipeText, imagePath, recipeDto.CookingTime, user, categoryList, ingredientList);
        }
    }
}
