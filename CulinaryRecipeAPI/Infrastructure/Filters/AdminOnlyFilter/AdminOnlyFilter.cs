using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.ClaimsPrincipaExtractor;
using CulinaryRecipeAPI.UseCases.PermissionsServices.AdminPermissionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CulinaryRecipeAPI.Infrastructure.Filters.AdminOnlyFilter
{
    public class AdminOnlyFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly IClaimsPrincipalExtractor _claimsPrincipalExtractor;
        private readonly IAdminPermissionService _adminPermissionService;
        public AdminOnlyFilter(
            IClaimsPrincipalExtractor claimsPrincipalExtractor,
            IAdminPermissionService adminPermissionService
        ) 
        { 
            _claimsPrincipalExtractor = claimsPrincipalExtractor;
            _adminPermissionService = adminPermissionService;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                var userId = _claimsPrincipalExtractor.ExtractUserId(context.HttpContext.User);  
                var isAdmin = await _adminPermissionService.IsUserAdmin(userId);
                if(!isAdmin)
                {
                    context.Result = new ForbidResult();
                }
            }
            catch
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
