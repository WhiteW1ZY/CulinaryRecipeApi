using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.ClaimsPrincipaExtractor;
using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.QueryCollectionExtractor;
using CulinaryRecipeAPI.Infrastructure.Classes.Extractors.RequestExtractor;
using CulinaryRecipeAPI.Infrastructure.Filters.AdminOnlyFilter;
using CulinaryRecipeAPI.Infrastructure.Filters.RecipeFilters;
using CulinaryRecipeAPI.Infrastructure.Filters.UserFilters;
using CulinaryRecipeAPI.Infrastructure.Map.CategoryMapper;
using CulinaryRecipeAPI.Infrastructure.Map.IngredientMapper;
using CulinaryRecipeAPI.Infrastructure.Map.RecipeMapper;
using CulinaryRecipeAPI.Infrastructure.Map.UserMapper;
using CulinaryRecipeAPI.Infrastructure.Repository;
using CulinaryRecipeAPI.Infrastructure.Validators;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.CategoryCreater;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.ClaimCreater;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.IngredientCreater;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.JwtCreater;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.RecipeCreater;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.UserCreater;
using CulinaryRecipeAPI.UseCases.Classes.Decryptors;
using CulinaryRecipeAPI.UseCases.Classes.Encryptions;
using CulinaryRecipeAPI.UseCases.Classes.Encryptors;
using CulinaryRecipeAPI.UseCases.Classes.ExisterCheckers;
using CulinaryRecipeAPI.UseCases.Classes.Handlers;
using CulinaryRecipeAPI.UseCases.Classes.Parsers;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.CategorySearcher;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.IngredientSearcher;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.RecipeSearcher;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.SearchType;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.UserSearcher;
using CulinaryRecipeAPI.UseCases.PermissionsServices.AdminPermissionService;
using CulinaryRecipeAPI.UseCases.PermissionsServices.RecipePermissionService;
using CulinaryRecipeAPI.UseCases.PermissionsServices.UserPermissionService;
using CulinaryRecipeAPI.UseCases.Repository;
using CulinaryRecipeAPI.UseCases.Services;
using CulinaryRecipeAPI.UseCases.Validators.CategoryDtoValidator;
using CulinaryRecipeAPI.UseCases.Validators.IngredientDtoValidator;
using CulinaryRecipeAPI.UseCases.Validators.RecipeDtoValidator;
using CulinaryRecipeAPI.UseCases.Validators.UserDtoValidator;

namespace CulinaryRecipeAPI.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        { 
            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddScoped<IUserDtoValidator, UserDtoValidator>();
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IUserCreater, UserCreater>();
            services.AddScoped<IUserSearcher, UserSearcher>();
            services.AddScoped<UserServiceAsync>();

            services.AddScoped<IRecipeRepositoryAsync, RecipeRepositoryAsync>();
            services.AddScoped<IRecipeDependenciesProcessor, RecipeDependenciesProcessor>();
            services.AddScoped<IRecipeDtoValidator, RecipeDtoValidator>();
            services.AddScoped<IRecipeMapper, RecipeMapper>();
            services.AddScoped<IRecipeCreater, RecipeCreater>();
            services.AddScoped<IRecipeSearcher, RecipeSearcher>();
            services.AddScoped<RecipeServiceAsync>();

            services.AddScoped<IIngredientRepositoryAsync, IngredientRepositoryAsync>();
            services.AddScoped<IIngredientMapper, IngredientMapper>();
            services.AddScoped<IIngredientDtoValidator, IngredientDtoValidator>();
            services.AddScoped<IIngredientCreater, IngredientCreater>();
            services.AddScoped<IIngredientSearcher, IngredientSearcher>();
            services.AddScoped<IngredientServiceAsync>();

            services.AddScoped<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
            services.AddScoped<ICategoryMapper, CategoryMapper>();
            services.AddScoped<ICategoryDtoValidator, CategoryDtoValidator>();
            services.AddScoped<ICategoryCreater, CategoryCreater>();
            services.AddScoped<ICategorySearcher, CategorySearcher>();
            services.AddScoped<CategoryServiceAsync>();

            services.AddScoped<IRecipePermissionService, RecipePermissionService>();
            services.AddScoped<IAdminPermissionService, AdminPermissionService>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();

            services.AddScoped<AuthorizationServiceAsync>();

            services.AddScoped<RecipeCreateFilter>();
            services.AddScoped<RecipeModifyFilter>();
            services.AddScoped<UserModifyFilter>();
            services.AddScoped<AdminOnlyFilter>();

            services.AddScoped<ITypeSearcher, TypeSearcher>();
            services.AddScoped<IUserExisterChecker, UserExisterChecker>();

            services.AddScoped<IRequestExtractor, RequestExtractor>();
            services.AddScoped<IHttpContextExtractor, HttpContextExtractor>();
            services.AddScoped<IRequestValidator, RequestValidator>();
            
            services.AddSingleton<IClaimsPrincipalExtractor, ClaimsPrincipalExtractor>();
            services.AddSingleton<IClaimCreater, ClaimCreater>();
            services.AddSingleton<IJwtCreater, JwtCreater>();
            services.AddSingleton<IPasswordEncryptor, BCryptPasswordEncryptor>();
            services.AddSingleton<IPasswordVerifier, PasswordVerifier>(); 
            services.AddSingleton<IRoleParser, RoleParser>();

            return services;
        }
    }
}
