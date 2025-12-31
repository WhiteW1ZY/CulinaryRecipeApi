
namespace CulinaryRecipeAPI.UseCases.PermissionsServices.AdminPermissionService
{
    public interface IAdminPermissionService
    {
        public Task<bool> IsUserAdmin(int userId);
    }
}
