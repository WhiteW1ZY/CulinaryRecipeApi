using CulinaryRecipeAPI.Domain.Enums;
using System.Security.Claims;

namespace CulinaryRecipeAPI.Infrastructure.Classes.Extractors.ClaimsPrincipaExtractor
{
    public interface IClaimsPrincipalExtractor
    { 
        int ExtractUserId(ClaimsPrincipal claimsPrincipal);
    }
}
