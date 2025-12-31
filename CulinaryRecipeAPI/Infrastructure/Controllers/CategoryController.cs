using CulinaryRecipeAPI.Infrastructure.Dto.Response;
using CulinaryRecipeAPI.Infrastructure.Filters.AdminOnlyFilter;
using CulinaryRecipeAPI.Infrastructure.Map.CategoryMapper;
using CulinaryRecipeAPI.Infrastructure.Models;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryRecipeAPI.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly CategoryServiceAsync _categoryServiceAsync;
        private readonly ICategoryMapper _categoryMapper;
        public CategoryController(
            CategoryServiceAsync categoryServiceAsync,
            ICategoryMapper categoryMapper
            )
        {
            _categoryServiceAsync = categoryServiceAsync;
            _categoryMapper = categoryMapper;
        }
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)] 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAllCategories()
        {
            var categories = await _categoryServiceAsync.GetAllCategories();
            var mappedCategories = _categoryMapper.ToIEnumerableCategoryResponseDto(categories);
            return Ok(mappedCategories);
        } 
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryResponseDto>> GetCategoryById(int id)
        {
            var category = await _categoryServiceAsync.GetCategoryById(id);
            var mappedCategory = _categoryMapper.ToCategoryResponseDto(category);
            return Ok(mappedCategory);
        }
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpPost]
        [ServiceFilter(typeof(AdminOnlyFilter))]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            var category = await _categoryServiceAsync.CreateCategory(categoryDto);
            var mappedCategory = _categoryMapper.ToCategoryResponseDto(category);
            return CreatedAtAction(
                nameof(GetCategoryById),
                new { id = mappedCategory.Id },
                mappedCategory);
        }
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(AdminOnlyFilter))]
        public async Task<ActionResult<CategoryResponseDto>> UpdateCategory(int id,[FromBody] CategoryDto categoryDto)
        {
            var category = await _categoryServiceAsync.UpdateCategory(id, categoryDto);
            var mappedCategory = _categoryMapper.ToCategoryResponseDto(category);
            return Ok(mappedCategory);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(AdminOnlyFilter))]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryServiceAsync.RemoveCategory(id);
            return NoContent();
        }
    }
}
