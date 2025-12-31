using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.ClaimsPrincipaExtractor;
using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.QueryCollectionExtractor; 
using CulinaryRecipeAPI.UseCases.PermissionsServices.RecipePermissionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; 

namespace CulinaryRecipeAPI.Infrastructure.Filters.RecipeFilters
{
    public class RecipeModifyFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly IClaimsPrincipalExtractor _claimsPrincipalExtractor;
        private readonly IHttpContextExtractor _httpContextExtractor;
        private readonly IRecipePermissionService _recipePermissionService;
        public RecipeModifyFilter( 
            IClaimsPrincipalExtractor claimsPrincipalExtractor,
            IHttpContextExtractor httpContextExtractor,
            IRecipePermissionService recipePermissionService
        )
        { 
            _claimsPrincipalExtractor = claimsPrincipalExtractor;
            _httpContextExtractor = httpContextExtractor;
            _recipePermissionService = recipePermissionService;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        { 
            try
            {
                var httpContext = context.HttpContext;  
                var recipeId = _httpContextExtractor.ExtractId(httpContext);
                var userId = _claimsPrincipalExtractor.ExtractUserId(httpContext.User); 

                var hasPermissions = await _recipePermissionService.CanUserModifyRecipeAsync(userId, recipeId);
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
