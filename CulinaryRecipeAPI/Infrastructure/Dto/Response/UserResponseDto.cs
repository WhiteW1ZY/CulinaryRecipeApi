namespace CulinaryRecipeAPI.Infrastructure.Dto.Response
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; } 
        public String Role { get; set; }
        public List<int> RecipesId { get; set; }
    }
}
