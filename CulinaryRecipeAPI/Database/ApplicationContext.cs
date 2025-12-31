using CulinaryRecipeAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryRecipeAPI.Database
{
    public class ApplicationContext: DbContext
    {   
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set;} = null!;
    }
}
