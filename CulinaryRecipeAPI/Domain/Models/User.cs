using CulinaryRecipeAPI.Domain.Enums;

namespace CulinaryRecipeAPI.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; } 
        public String Email { get; set; }
        public String HashedPassword { get; set; }
        public Role UserRole { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
        private User() { }
        public User(String userName, String email, String hashedPassword, Role role)
        {
            Name = userName;
            Email = email;
            HashedPassword = hashedPassword;
            UserRole = role;
            Recipes = new List<Recipe>();
        }
    }
}
