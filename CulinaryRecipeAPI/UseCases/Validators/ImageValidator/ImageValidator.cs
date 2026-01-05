
using CulinaryRecipeAPI.UseCases.Contants;
using CulinaryRecipeAPI.UseCases.Exceptions;

namespace CulinaryRecipeAPI.UseCases.Validators.ImageValidator
{
    public class ImageValidator : IImageValidator
    {
        public void Validate(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            if (string.IsNullOrEmpty(extension) || !ImageConstants.allowedExtensions.Contains(extension))
            {
                throw new ValidationException($"Image cannot contain {extension} type of extension");
            }
            else if (image.Length > ImageConstants.limitImageSize)
            {
                throw new ValidationException($"Image must not exceed the size limit");
            }
        }
    }
}
