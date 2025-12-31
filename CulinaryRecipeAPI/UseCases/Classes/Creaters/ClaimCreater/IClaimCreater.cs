using CulinaryRecipeAPI.UseCases.Dto;
using System.Security.Claims;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.ClaimCreater
{
    public interface IClaimCreater
    {
        public IEnumerable<Claim> CreateFromDto(ClaimDto claimDto);
    }
}
