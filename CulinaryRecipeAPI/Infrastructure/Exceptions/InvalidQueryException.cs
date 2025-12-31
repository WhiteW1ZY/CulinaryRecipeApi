namespace CulinaryRecipeAPI.Infrastructure.Exceptions
{
    public class InvalidQueryException: Exception
    {
        public InvalidQueryException(string message) : base(message) { }
    }
}
