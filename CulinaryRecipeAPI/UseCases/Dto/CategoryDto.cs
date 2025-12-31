namespace CulinaryRecipeAPI.UseCases.Dto
{
    public class CategoryDto
    {
        public String Name { get; set; }
        public CategoryDto(String name)
        {
            Name = name;
        }
    }
}
