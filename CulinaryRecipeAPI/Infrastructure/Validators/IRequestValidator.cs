namespace CulinaryRecipeAPI.Infrastructure.Validators
{
    public interface IRequestValidator
    {
        void ValidateJsonContent(HttpRequest request);
    }
}
