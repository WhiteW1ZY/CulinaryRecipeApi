using CulinaryRecipeAPI.UseCases.PermissionsServices.AdminPermissionService;
using CulinaryRecipeAPI.UseCases.Repository; 

namespace CulinaryRecipeAPI.UseCases.PermissionsServices.RecipePermissionService
{
    public class RecipePermissionService : IRecipePermissionService
    {
        private readonly IRecipeRepositoryAsync _recipeRepository;
        private readonly IAdminPermissionService _adminPermissionService;
        public RecipePermissionService(
            IRecipeRepositoryAsync recipeRepository,
            IAdminPermissionService adminPermissionService
            )
        {
            _recipeRepository = recipeRepository;
            _adminPermissionService = adminPermissionService;
        }
        public async Task<bool> CanUserModifyRecipeAsync(int userId, int recipeId)
        {
            var isAdmin = await _adminPermissionService.IsUserAdmin(userId); 
            if (isAdmin)
            {
                return true;
            }

            var recipe = await _recipeRepository.GetRecipeById(recipeId);

            if ((recipe == null) || (recipe.Author == null) || (recipe.Author.Id != userId))
            {
                return false;
            }
            return true;
        }
        public async Task<bool> CanUserCreateRecipe(int userId, int authorId)
        {
            if(userId == authorId)
            {
                return true; 
            }
            var isAdmin = await _adminPermissionService.IsUserAdmin(userId);
            return isAdmin;
        }
    }
}
