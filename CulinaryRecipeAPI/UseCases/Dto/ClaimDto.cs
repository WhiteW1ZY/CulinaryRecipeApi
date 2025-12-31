namespace CulinaryRecipeAPI.UseCases.Dto
{
    public class ClaimDto
    {
        public String Id;
        public String Email;
        public String UserName;
        public String Role;
        public ClaimDto(String id, String email, String userName, String role)
        {
            Id = id;
            Email = email;
            UserName = userName;
            Role = role;
        }
    }
}
