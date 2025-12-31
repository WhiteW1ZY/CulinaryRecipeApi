namespace CulinaryRecipeAPI.Infrastructure.Exceptions
{
    public class ForbiddenException: Exception
    {
        public ForbiddenException(String message): base(message) { }
    }
}
