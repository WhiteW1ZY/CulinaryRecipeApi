namespace CulinaryRecipeAPI.Infrastructure.Classes.Extractors.RequestExtractor
{
    public interface IJsonRequestExtractor
    {
        Task<T> ExtractType<T>(HttpRequest request);
        Task<String> ExtractRequestBody(HttpRequest request);
    }
}
