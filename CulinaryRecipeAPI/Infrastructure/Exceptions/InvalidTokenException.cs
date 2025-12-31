namespace CulinaryRecipeAPI.Infrastructure.Exceptions
{
    public class InvalidTokenException: Exception
    {
        public InvalidTokenException(String message): base(message) {}  
    }
}
