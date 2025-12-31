using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Validators.UserDtoValidator
{
    public interface IUserDtoValidator
    {
        public void Validate(UserDto user);
    }
}
