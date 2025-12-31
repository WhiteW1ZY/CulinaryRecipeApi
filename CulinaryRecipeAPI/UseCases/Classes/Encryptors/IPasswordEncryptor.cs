namespace CulinaryRecipeAPI.UseCases.Classes.Encryptors
{
    public interface IPasswordEncryptor
    {
        public String Encrypt(String password);
        public bool Verify(String password, String hashedPassword);
    }
}
