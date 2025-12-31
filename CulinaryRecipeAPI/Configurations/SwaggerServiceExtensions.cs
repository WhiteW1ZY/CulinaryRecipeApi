using Microsoft.OpenApi;

public static class SwaggerServiceExtensions
{
    public static void AddSwaggerWithJwtAuth(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            const string schemeId = "Bearer";
            options.AddSecurityDefinition(schemeId, new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'"
            });

            options.AddSecurityRequirement(document =>
            {
                var schemeRef = new OpenApiSecuritySchemeReference("Bearer", document);

                return new OpenApiSecurityRequirement()
                {
                    [schemeRef] = []
                };
            });
        });
    }
}