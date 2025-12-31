using CulinaryRecipeAPI.Domain.Models;
using CulinaryRecipeAPI.Infrastructure.Dto.Response;

namespace CulinaryRecipeAPI.Infrastructure.Map.UserMapper
{
    public class UserMapper : IUserMapper
    {
        public UserResponseDto ToUserResponseDto(User user) =>
            new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.UserRole.ToString(), 
                RecipesId = [.. user.Recipes.Select(r => r.Id)]
            };
        public IEnumerable<UserResponseDto> ToIEnumberableUserResponseDto(IEnumerable<User> users) =>
            users.Select(ToUserResponseDto);
    }
}
