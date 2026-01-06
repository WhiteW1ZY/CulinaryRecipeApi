using CulinaryRecipeAPI.Infrastructure.Exceptions;
using CulinaryRecipeAPI.Infrastructure.Validators;

namespace CulinaryRecipeAPI.Infrastructure.Classes.Extractors.FormDataRequestExtractor
{
    public class FormDataRequestExtractor: IFormDataRequestExtractor
    {
        private IRequestValidator _requestValidator;
        public FormDataRequestExtractor(IRequestValidator requestValidator)
        {
            _requestValidator = requestValidator;
        }
        public async Task<int> ExtractId(HttpRequest request)
        {
            _requestValidator.ValidateFormContent(request);
            var form = await request.ReadFormAsync();
            var authorIdValue = form["AuthorId"].FirstOrDefault(); 
            if (!int.TryParse(authorIdValue, out int authorId))
            {
                throw new InvalidQueryException("Uncurrent query id format");
            }
            return authorId;
        }
    }
}
