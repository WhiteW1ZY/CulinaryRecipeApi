using CulinaryRecipeAPI.UseCases.PermissionsServices.AdminPermissionService;
using CulinaryRecipeAPI.UseCases.Repository;

namespace CulinaryRecipeAPI.UseCases.PermissionsServices.UserPermissionService
{
    public class UserPermissionService : IUserPermissionService
    {
        private IUserRepositoryAsync _userRepositoryAsync;
        private IAdminPermissionService _adminPermissionService;
        public UserPermissionService(
            IUserRepositoryAsync userRepositoryAsync,
            IAdminPermissionService adminPermissionService
            ) 
        { 
            _userRepositoryAsync = userRepositoryAsync;
            _adminPermissionService = adminPermissionService;
        }
        public async Task<bool> CanUserModifyUserAsync(int userId, int updatingUserId)
        {
            var isAdmin = await _adminPermissionService.IsUserAdmin(userId);
            if (isAdmin)
            {
                return true;
            }
            var user = await _userRepositoryAsync.GetUserById(updatingUserId);

            if ((user == null) || (user.Id != userId))
            {
                return false;
            }
            return true;
        }
    }
}
