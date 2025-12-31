using CulinaryRecipeAPI.UseCases.Classes.Creaters.ClaimCreater;
using CulinaryRecipeAPI.UseCases.Classes.Creaters.JwtCreater;
using CulinaryRecipeAPI.UseCases.Classes.Decryptors;
using CulinaryRecipeAPI.UseCases.Classes.Searchers.UserSearcher;
using CulinaryRecipeAPI.UseCases.Dto;

namespace CulinaryRecipeAPI.UseCases.Services
{
    public class AuthorizationServiceAsync
    {
        private readonly IUserSearcher _userSearcher;
        private readonly IPasswordVerifier _passwordVerifier;
        private readonly IClaimCreater _claimCreater;
        private readonly IJwtCreater _jwtCreater;
        public AuthorizationServiceAsync(
            IUserSearcher userSearcher,
            IPasswordVerifier passwordVerifier,
            IClaimCreater claimCreater,
            IJwtCreater jwtCreater
        )
        {
            _userSearcher = userSearcher;
            _passwordVerifier = passwordVerifier;
            _claimCreater = claimCreater;
            _jwtCreater = jwtCreater;
        }
        public async Task<String> GenerateAuthorizationToken(AuthorizationUserDto authorizationUserDto)
        {
            var user = await _userSearcher.SearchByLoginAsync(authorizationUserDto.Login);
            _passwordVerifier.Verify(authorizationUserDto.Password, user.HashedPassword);
            var claims = _claimCreater.CreateFromDto(new ClaimDto(user.Id.ToString(), user.Email, user.Name, user.UserRole.ToString())); 
            var jwt = _jwtCreater.CreateStringTokenFromClaims(claims);
            return jwt;
        }
    }
}
