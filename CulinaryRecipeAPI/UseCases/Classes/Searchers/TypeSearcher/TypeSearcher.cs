using CulinaryRecipeAPI.UseCases.Exceptions;

namespace CulinaryRecipeAPI.UseCases.Classes.Searchers.SearchType
{
    public class TypeSearcher: ITypeSearcher
    {
        public async Task<T> Search<T>(Func<Task<T?>> repositoryCall, string errorMessage) where T: class
        {
            var type = await repositoryCall();
            return type ?? throw new NotFoundException(errorMessage);
        }
    }
}
