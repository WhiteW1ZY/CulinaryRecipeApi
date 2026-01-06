namespace CulinaryRecipeAPI.Infrastructure.Classes.Extractors.FormDataRequestExtractor
{
    public interface IFormDataRequestExtractor
    { 
        Task<int> ExtractId(HttpRequest request);
    }
}
