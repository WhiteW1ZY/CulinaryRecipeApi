using CulinaryRecipeAPI.Configurations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.JwtCreater
{
    public class JwtCreater : IJwtCreater
    {
        public String CreateStringTokenFromClaims(IEnumerable<Claim> claims)
        {
            var jst = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(jst);
            return jwt;
        }
            
    }
}
