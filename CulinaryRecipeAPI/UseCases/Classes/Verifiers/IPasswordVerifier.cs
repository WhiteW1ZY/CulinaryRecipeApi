namespace CulinaryRecipeAPI.UseCases.Classes.Decryptors
{
    public interface IPasswordVerifier
    {
        public void Verify(String password, String hashedPassword);
    }
}
