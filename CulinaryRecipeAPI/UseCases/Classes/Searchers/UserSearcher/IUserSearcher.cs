using CulinaryRecipeAPI.Domain.Models;

namespace CulinaryRecipeAPI.UseCases.Classes.Searchers.UserSearcher
{
    public interface IUserSearcher
    {
        public Task<User> SearchByIdAsync(int userId);
        public Task<User> SearchByLoginAsync(String login);
    }
}
