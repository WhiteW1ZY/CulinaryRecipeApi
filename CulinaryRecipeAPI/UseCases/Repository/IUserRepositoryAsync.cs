using CulinaryRecipeAPI.Domain.Models; 

namespace CulinaryRecipeAPI.UseCases.Repository
{
    public interface IUserRepositoryAsync
    {
        public Task<User?> GetUserById(int userId);
        public Task<User?> GetUserByLogin(String login);
        public Task<User?> GetUserByEmail(String email); 
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> CreateUser(User user);
        public Task<User> UpdateUser(User user, User newUser);
        public Task RemoveUser(User user);
    }
}
