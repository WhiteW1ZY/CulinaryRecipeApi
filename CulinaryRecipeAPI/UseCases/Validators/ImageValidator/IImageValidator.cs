namespace CulinaryRecipeAPI.UseCases.Validators.ImageValidator
{
    public interface IImageValidator
    {
        public void Validate(IFormFile image);
    }
}
