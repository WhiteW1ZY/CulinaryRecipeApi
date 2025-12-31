
namespace CulinaryRecipeAPI.Infrastructure.Validators
{
    public class RequestValidator : IRequestValidator
    {
        public void ValidateJsonContent(HttpRequest request)
        {
            if (!request.HasJsonContentType())
                throw new InvalidOperationException($"Expected JSON, got {request.ContentType}");
        }
    }
}
