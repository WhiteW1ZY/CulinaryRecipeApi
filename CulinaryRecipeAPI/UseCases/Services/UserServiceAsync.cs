using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.UserCreater;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.UserSearcher;
using CulinaryRecipeAPI.UseCases.Dto; 
using CulinaryRecipeAPI.UseCases.Repository; 

namespace CulinaryRecipeAPI.UseCases.Services
{
    public class UserServiceAsync
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync; 
        private readonly IUserCreater _userCreater;
        private readonly IUserSearcher _userSearcher;
        public UserServiceAsync(
            IUserRepositoryAsync userRepositoryAsync, 
            IUserCreater userCreater,
            IUserSearcher userSearcher
            ) 
        {
            _userRepositoryAsync = userRepositoryAsync; 
            _userCreater = userCreater;
            _userSearcher = userSearcher;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepositoryAsync.GetAllUsers();        
        }
        public async Task<User> GetUserById(int id)
        {
            return await _userSearcher.SearchByIdAsync(id);
        }
        public async Task<User> CreateUser(UserDto userDto)
        {
            var user = await _userCreater.CreateFromDtoUniqueAsync(userDto);
            var createdUser = await _userRepositoryAsync.CreateUser(user); 
            return createdUser;
        }
        public async Task<User> UpdateUser(int userId, UserDto userDto)
        {
            var newUser = await _userCreater.CreateFromDtoAsync(userDto);
            var user = await _userSearcher.SearchByIdAsync(userId);
            var updatedUser = await _userRepositoryAsync.UpdateUser(user, newUser);
            return updatedUser;
        }
        public async Task RemoveUserById(int userId)
        {
            var user = await _userSearcher.SearchByIdAsync(userId);
            await _userRepositoryAsync.RemoveUser(user);
        }
    }
}
