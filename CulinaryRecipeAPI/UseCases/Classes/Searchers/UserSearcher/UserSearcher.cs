using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.SearchType;
using CulinaryRecipeAPI.UseCases.Repository;

namespace CulinaryRecipeAPI.UseCases.Classes.Searchers.UserSearcher
{
    public class UserSearcher: IUserSearcher
    {
        private IUserRepositoryAsync _userRepositoryAsync;
        private ITypeSearcher _typeSearcher;
        public UserSearcher(
            IUserRepositoryAsync userRepositoryAsync,
            ITypeSearcher typeSearcher
            )
        {
            _userRepositoryAsync = userRepositoryAsync;
            _typeSearcher = typeSearcher; 
        }
        public async Task<User> SearchByIdAsync(int userId) =>
            await _typeSearcher.Search<User>(
                () => _userRepositoryAsync.GetUserById(userId),
                $"User with id {userId} not found"
            );
        public async Task<User> SearchByLoginAsync(string login) => 
            await _typeSearcher.Search<User>(
                () => _userRepositoryAsync.GetUserByLogin(login), 
                $"User with login {login} not found"
            ); 
    }
}
