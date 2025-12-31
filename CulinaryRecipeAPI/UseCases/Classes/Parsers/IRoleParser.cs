using CulinaryRecipeAPI.Domain.Enums;

namespace CulinaryRecipeAPI.UseCases.Classes.Parsers
{
    public interface IRoleParser
    {
        Role GetFromString(string roleString);
    }
}
