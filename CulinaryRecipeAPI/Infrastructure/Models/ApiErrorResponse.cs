namespace CulinaryRecipeAPI.Infrastructure.Models
{
    public class ApiErrorResponse
    {
        public String Instance { get; set; }
        public int Status { get; set; }
        public String Title { get; set; }
        public String Detail { get; set; }
    }
}
