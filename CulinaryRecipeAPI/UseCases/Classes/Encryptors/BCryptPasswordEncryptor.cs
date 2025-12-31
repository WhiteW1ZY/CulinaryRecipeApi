using CulinaryRecipeAPI.UseCases.Classes.Encryptors;

namespace CulinaryRecipeAPI.UseCases.Classes.Encryptions
{
    public class BCryptPasswordEncryptor : IPasswordEncryptor
    {
        public String Encrypt(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public bool Verify(String password, String hashedPassword) => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
