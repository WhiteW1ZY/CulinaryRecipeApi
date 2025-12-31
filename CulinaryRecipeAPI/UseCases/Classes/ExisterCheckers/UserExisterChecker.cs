using CulinaryRecipeAPI.UseCases.Exceptions;
using CulinaryRecipeAPI.UseCases.Repository;

namespace CulinaryRecipeAPI.UseCases.Classes.ExisterCheckers
{
    public class UserExisterChecker : IUserExisterChecker
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        public UserExisterChecker(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        } 
        public async Task CheckByEmailAsync(string email)
        {
            var userByEmail = await _userRepositoryAsync.GetUserByEmail(email);
            if (userByEmail != null)
            {
                throw new AlreadyExistExeption($"User with email {email} already exist");
            }
        } 
    }
}
