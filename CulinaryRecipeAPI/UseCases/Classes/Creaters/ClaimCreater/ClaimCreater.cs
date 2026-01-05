using CulinaryRecipeAPI.UseCases.Dto; 
using System.Security.Claims;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.ClaimCreater
{
    public class ClaimCreater : IClaimCreater
    {
        public IEnumerable<Claim> CreateFromDto(ClaimDto claimDto) =>
            new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, claimDto.Id), 
                new Claim(ClaimTypes.Name, claimDto.UserName), 
                new Claim(ClaimTypes.Email, claimDto.Email),
                new Claim(ClaimTypes.Role, claimDto.Role),
            };
    }
}
