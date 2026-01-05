namespace CulinaryRecipeAPI.UseCases.Classes.Creaters.ImageCreater
{
    public interface IImageCreater
    {
        Task<String> CreateImageByFormFileAsync(IFormFile image);
    }
}
