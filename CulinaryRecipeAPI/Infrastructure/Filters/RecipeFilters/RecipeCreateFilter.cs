using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.ClaimsPrincipaExtractor;
using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.FormDataRequestExtractor;
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
        private readonly IFormDataRequestExtractor _formDataRequestExtractor;
        public RecipeCreateFilter(
            IClaimsPrincipalExtractor claimsPrincipalExtractor, 
            IRecipePermissionService recipePermissionService,
            IFormDataRequestExtractor formDataRequestExtractor
        )
        {
            _claimsPrincipalExtractor = claimsPrincipalExtractor; 
            _recipePermissionService = recipePermissionService; 
            _formDataRequestExtractor = formDataRequestExtractor;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                var httpContext = context.HttpContext;  
                var userId = _claimsPrincipalExtractor.ExtractUserId(httpContext.User); 
                var authorIdValue = await _formDataRequestExtractor.ExtractId(httpContext.Request); 
                var hasPermissions = await _recipePermissionService.CanUserCreateRecipe(userId, authorIdValue);
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
