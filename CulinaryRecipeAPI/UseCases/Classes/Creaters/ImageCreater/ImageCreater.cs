using CulinaryRecipeAPI.UseCases.Validators.ImageValidator;

namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.ImageCreater
{
    public class ImageCreater : IImageCreater
    {
        private readonly IImageValidator _imageValidator;
        public ImageCreater(IImageValidator imageValidator)
        {
            _imageValidator = imageValidator; 
        }
        public async Task<string> CreateImageByFormFileAsync(IFormFile image)
        {
            _imageValidator.Validate(image);

            var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

            var uploadsDir = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(uploadsDir))
                Directory.CreateDirectory(uploadsDir!);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
