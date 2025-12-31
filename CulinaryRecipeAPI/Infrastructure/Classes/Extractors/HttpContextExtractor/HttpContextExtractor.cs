using CulinaryRecipeAPI.Infrastructure.Exceptions; 

namespace CulinaryRecipeAPI.Infrastructure.Classes.Extractors.QueryCollectionExtractor
{
    public class HttpContextExtractor : IHttpContextExtractor
    {  
        public int ExtractId(HttpContext httpContext)
        {
            var idFromRoute = httpContext.GetRouteValue("id");
            if (idFromRoute == null || !int.TryParse(idFromRoute.ToString(), out int id))
            {
                throw new InvalidQueryException("Uncurrent query id format");
            } 
            return id;
        } 
    }
}
