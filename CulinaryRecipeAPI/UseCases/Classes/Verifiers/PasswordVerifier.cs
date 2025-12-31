using CulinaryRecipeAPI.UseCases.Classes.Encryptors;
using CulinaryRecipeAPI.UseCases.Exceptions;

namespace CulinaryRecipeAPI.UseCases.Classes.Decryptors
{
    public class PasswordVerifier : IPasswordVerifier
    {
        private readonly IPasswordEncryptor _passwordEncryptor;
        public PasswordVerifier(IPasswordEncryptor passwordEncryptor)
        {
            _passwordEncryptor = passwordEncryptor;
        }
        public void Verify(String password, String hashedPassword)
        {
            var isVerified = _passwordEncryptor.Verify(password, hashedPassword);
            if (!isVerified)
            {
                throw new NotFoundException($"Password cannot be verified");
            }
        }
    }
}
