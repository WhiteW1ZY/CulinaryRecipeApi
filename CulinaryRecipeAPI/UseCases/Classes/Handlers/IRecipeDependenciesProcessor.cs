using CulinaryRecipeAPI.Domain.Models;

namespace CulinaryRecipeAPI.UseCases.Classes.Handlers
{
    public interface IRecipeDependenciesProcessor
    {
        public Task ProcessRecipeDependenciesAsync(Recipe recipe);
    }
}
