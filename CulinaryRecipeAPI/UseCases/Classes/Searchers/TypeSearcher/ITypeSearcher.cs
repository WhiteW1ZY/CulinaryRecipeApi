namespace CulinaryRecipeAPI.UseCases.Classes.Searchers.SearchType
{
    public interface ITypeSearcher
    {
        public Task<T> Search<T>(Func<Task<T?>> repositoryCall, string errorMessage) where T : class;
    }
}
