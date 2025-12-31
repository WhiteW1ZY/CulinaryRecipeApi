using CulinaryRecipeAPI.Domain.Enums;

namespace CulinaryRecipeAPI.UseCases.PermissionsServices.UserPermissionService
{
    public interface IUserPermissionService
    {
        public Task<bool> CanUserModifyUserAsync(int userId, int updatingUserId);
    }
}
