using CulinaryRecipeAPI.Infrastructure.Exceptions;
using System.Security.Claims;

namespace CulinaryRecipeAPI.Infrastructure.Classes.Extractors.ClaimsPrincipaExtractor
{
    public class ClaimsPrincipalExtractor: IClaimsPrincipalExtractor
    {  
        public int ExtractUserId(ClaimsPrincipal claimsPrincipal)
        {
            var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier) 
                ?? throw new InvalidTokenException("Claim types doesn't contains user id");

            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                throw new InvalidTokenException("Claim types contains invalid user id format");
            }

            return userId;
        }
    }
}
