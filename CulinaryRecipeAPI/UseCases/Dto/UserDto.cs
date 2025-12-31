using CulinaryRecipeAPI.Domain.Enums;

namespace CulinaryRecipeAPI.UseCases.Dto
{
    public class UserDto
    {  
        public String Name { get; set; } 
        public String Email { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
    }
}
