using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.UserCreater
{
    public interface IUserCreater
    {
        public Task<User> CreateFromDtoAsync(UserDto userDto);
        public Task<User> CreateFromDtoUniqueAsync(UserDto userDto);
    }
}
