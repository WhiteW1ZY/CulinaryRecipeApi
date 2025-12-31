using CulinaryRecipeAPI.Infrastructure.Validators;
using System.Text;
using System.Text.Json;

namespace CulinaryRecipeAPI.Infrastructure.Classes.Extractors.RequestExtractor
{
    public class RequestExtractor : IRequestExtractor
    {
        private readonly IRequestValidator _requestValidator;
        public RequestExtractor(IRequestValidator requestValidator)
        {
            _requestValidator = requestValidator;
        } 
        public async Task<String> ExtractRequestBody(HttpRequest request)
        {
            _requestValidator.ValidateJsonContent(request);
            request.EnableBuffering();

            using var reader = new StreamReader(
                request.Body,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: -1,
                leaveOpen: true);

            var body = await reader.ReadToEndAsync();

            request.Body.Position = 0;

            return body;
        } 
        public async Task<T> ExtractType<T>(HttpRequest request)
        { 
            var body = await ExtractRequestBody(request);
            try
            {
                var type = JsonSerializer.Deserialize<T>(
                    body,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return type ?? throw new JsonException("Deserialization returned null");
            }
            catch (JsonException ex)
            {
                throw new JsonException($"Failed to deserialize JSON to type {typeof(T).Name}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error processing request body: {ex.Message}", ex);
            }
        }
    }
}
