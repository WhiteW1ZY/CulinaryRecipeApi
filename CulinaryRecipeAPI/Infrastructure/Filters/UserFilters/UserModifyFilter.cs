using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.ClaimsPrincipaExtractor;
using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.QueryCollectionExtractor;
using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.RequestExtractor;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.PermissionsServices.UserPermissionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CulinaryRecipeAPI.Infrastructure.Filters.UserFilters
{
    public class UserModifyFilter : Attribute, IAsyncAuthorizationFilter
    { 
        private readonly IClaimsPrincipalExtractor _claimsPrincipalExtractor;
        private readonly IHttpContextExtractor _httpContextExtractor;
        private readonly IUserPermissionService _userPermissionService;
        public UserModifyFilter( 
            IClaimsPrincipalExtractor claimsPrincipalExtractor,
            IHttpContextExtractor httpContextExtractor,
            IUserPermissionService userPermissionService
        )
        { 
            _claimsPrincipalExtractor = claimsPrincipalExtractor;
            _httpContextExtractor = httpContextExtractor;
            _userPermissionService = userPermissionService;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                var httpContext = context.HttpContext;
                var userId = _claimsPrincipalExtractor.ExtractUserId(httpContext.User); 
                var updatingUserId = _httpContextExtractor.ExtractId(httpContext);

                var hasPermissions = await _userPermissionService.CanUserModifyUserAsync(userId, updatingUserId);
                if (!hasPermissions)
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
