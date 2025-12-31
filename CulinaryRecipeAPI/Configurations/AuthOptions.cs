using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CulinaryRecipeAPI.Configurations
{
    public class AuthOptions
    {
        public const string ISSUER = "CulinaryRecipeApi";
        public const string AUDIENCE = "CulinaryRecipeClient";
        const string KEY = "mysupersecret_secretsecretsecretkey!123";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
