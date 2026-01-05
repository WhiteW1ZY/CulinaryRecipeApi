namespace CulinaryRecipeAPI.Infrastructure.Dto.Response
{
    public class RecipeResponseDto
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String RecipeText { get; set; }
        public String? ImagePath { get; set; }
        public int CookingTime { get; set; }
        public DateTime CreatingDate { get; set; }
        public int? AuthorId { get; set; }
        public IEnumerable<String> Categories { get; set; }
        public IEnumerable<String> Ingredients { get; set; } 
    }
}
