using CulinaryRecipeAPI.Domain.Enums;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.UserSearcher; 

namespace CulinaryRecipeAPI.UseCases.PermissionsServices.AdminPermissionService
{
    public class AdminPermissionService : IAdminPermissionService
    {
        private readonly IUserSearcher _userSearcher;
        public AdminPermissionService(IUserSearcher userSearcher)
        {
            _userSearcher = userSearcher;
        }
        public async Task<bool> IsUserAdmin(int userId)
        {
            var user = await _userSearcher.SearchByIdAsync(userId);
            return user.UserRole == Role.Admin;
        }
    }
}
