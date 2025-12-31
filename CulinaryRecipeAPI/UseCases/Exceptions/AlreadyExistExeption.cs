namespace CulinaryRecipeAPI.UseCases.Exceptions
{
    public class AlreadyExistExeption: Exception
    {
        public AlreadyExistExeption(string message): base(message) { }
    }
}
