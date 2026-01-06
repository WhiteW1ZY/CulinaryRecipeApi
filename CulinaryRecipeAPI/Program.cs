using CulinaryRecipeAPI.Configurations;
using CulinaryRecipeAPI.Database; 
using Microsoft.EntityFrameworkCore;  

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.ConfigureJwtAuthentication();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(connectionString)); 

builder.Services.AddApplicationServices(); 
builder.Services.AddEndpointsApiExplorer(); 

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
}); 

builder.Services.AddSwaggerWithJwtAuth();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection(); 
app.UseAuthentication();
app.UseAuthorization(); 
app.UseMiddleware<ExceptionHandlingMiddleware>(); 
app.MapControllers();

app.UseStaticFiles();

app.UseCors();

app.Run();
