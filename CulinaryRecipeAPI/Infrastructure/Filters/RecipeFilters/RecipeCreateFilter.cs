using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.ClaimsPrincipaExtractor;
using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.RequestExtractor;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.PermissionsServices.RecipePermissionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CulinaryRecipeAPI.Infrastructure.Filters.RecipeFilters
{
    public class RecipeCreateFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly IClaimsPrincipalExtractor _claimsPrincipalExtractor; 
        private readonly IRecipePermissionService _recipePermissionService;
        private readonly IRequestExtractor _requestExtractor;
        public RecipeCreateFilter(
            IClaimsPrincipalExtractor claimsPrincipalExtractor, 
            IRecipePermissionService recipePermissionService,
            IRequestExtractor requestExtractor
        )
        {
            _claimsPrincipalExtractor = claimsPrincipalExtractor; 
            _recipePermissionService = recipePermissionService;
            _requestExtractor = requestExtractor;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                var httpContext = context.HttpContext; 

                var userId = _claimsPrincipalExtractor.ExtractUserId(httpContext.User);

                var recipe = await _requestExtractor.ExtractType<RecipeDto>(httpContext.Request);

                var hasPermissions = await _recipePermissionService.CanUserModifyRecipeAsync(userId, recipe.AuthorId);
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
