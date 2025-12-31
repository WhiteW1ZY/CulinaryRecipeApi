using System.Security.Claims;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.JwtCreater
{
    public interface IJwtCreater
    {
        public String CreateStringTokenFromClaims(IEnumerable<Claim> claims);
    }
}
