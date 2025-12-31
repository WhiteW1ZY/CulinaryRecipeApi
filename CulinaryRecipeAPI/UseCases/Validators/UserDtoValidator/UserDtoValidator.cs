using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Exceptions;

namespace CulinaryRecipeAPI.UseCases.Validators.UserDtoValidator
{
    public class UserDtoValidator : IUserDtoValidator
    {
        public void Validate(UserDto user)
        {
            if(String.IsNullOrEmpty(user.Name))
            {
                throw new ValidationException("User name cannot be empty");
            }
            else if(string.IsNullOrEmpty(user.Email))
            {
                throw new ValidationException("Email cannot be empty");
            }
            else if (user.Password.Length < 5)
            {
                throw new ValidationException("Password should contains at least 5 symbols");
            }
        }
    }
}
