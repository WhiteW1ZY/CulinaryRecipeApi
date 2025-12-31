using CulinaryRecipeAPI.Domain.Enums;
using CulinaryRecipeAPI.UseCases.Exceptions;

namespace CulinaryRecipeAPI.UseCases.Classes.Parsers
{
    public class RoleParser : IRoleParser
    {
        public Role GetFromString(string roleString)
        { 
            if (!Enum.TryParse<Role>(roleString, true, out Role role))
            {
                throw new NotFoundException($"Role with name {roleString} not found");
            }
            return role;
        }
    }
}
