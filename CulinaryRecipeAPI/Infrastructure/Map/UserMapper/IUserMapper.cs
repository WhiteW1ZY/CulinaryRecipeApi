using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.Infrastructure.Dto.Response;

namespace CulinaryRecipeAPI.Infrastructure.Map.UserMapper
{
    public interface IUserMapper
    {
        public UserResponseDto ToUserResponseDto(User user);
        public IEnumerable<UserResponseDto> ToIEnumberableUserResponseDto(IEnumerable<User> users);
    }
}
