namespace CulinaryRecipeAPI.Infrastructure.Classes.Extractors.QueryCollectionExtractor
{
    public interface IHttpContextExtractor
    {
        int ExtractId(HttpContext httpContext);
    }
}
