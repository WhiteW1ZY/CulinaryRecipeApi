using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Classes.ExisterCheckers
{
    public interface IUserExisterChecker
    {
        public Task CheckByEmailAsync(String email);
    }
}
