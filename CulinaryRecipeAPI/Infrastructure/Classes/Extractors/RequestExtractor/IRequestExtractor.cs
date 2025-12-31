namespace CulinaryRecipeAPI.Infrastructure.Classes.Extractors.RequestExtractor
{
    public interface IRequestExtractor
    {
        Task<T> ExtractType<T>(HttpRequest request);
        Task<String> ExtractRequestBody(HttpRequest request);
    }
}
