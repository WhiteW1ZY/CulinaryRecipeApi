using CulinaryRecipeAPI.Domain.Models; 
using CulinaryRecipeAPI.UseCases.Classes.Encryptors;
using CulinaryRecipeAPI.UseCases.Classes.ExisterCheckers;
using CulinaryRecipeAPI.UseCases.Classes.Parsers;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Validators.UserDtoValidator;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.UserCreater
{
    public class UserCreater: IUserCreater
    {
        private readonly IUserDtoValidator _userDtoValidator;
        private readonly IPasswordEncryptor _dataEncryptor;
        private readonly IUserExisterChecker _userExisterChecker;
        private readonly IRoleParser _roleParser;
        public UserCreater(
            IUserDtoValidator userDtoValidator,
            IPasswordEncryptor dataEncryptor,
            IUserExisterChecker userExisterChecker,
            IRoleParser roleParser
            )
        {
            _userDtoValidator = userDtoValidator;
            _dataEncryptor = dataEncryptor;
            _userExisterChecker = userExisterChecker;
            _roleParser = roleParser;
        }
        public async Task<User> CreateFromDtoUniqueAsync(UserDto userDto)
        {
            await _userExisterChecker.CheckByEmailAsync(userDto.Email);
            var user = await CreateFromDtoAsync(userDto);
            return user;
        }
        public async Task<User> CreateFromDtoAsync(UserDto userDto)
        { 
            _userDtoValidator.Validate(userDto); 
            var hashedPassword = _dataEncryptor.Encrypt(userDto.Password);
            var role = _roleParser.GetFromString(userDto.Role);
            var user = new User(userDto.Name, userDto.Email, hashedPassword, role);
            return user;
        }
    }
}
