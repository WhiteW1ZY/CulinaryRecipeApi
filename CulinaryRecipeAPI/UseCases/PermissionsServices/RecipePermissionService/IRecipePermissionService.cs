namespace CulinaryRecipeAPI.UseCases.PermissionsServices.RecipePermissionService
{
    public interface IRecipePermissionService
    {
        public Task<bool> CanUserModifyRecipeAsync(int userId, int recipeId);
        public Task<bool> CanUserCreateRecipe(int userId, int authorId);
    }
}
