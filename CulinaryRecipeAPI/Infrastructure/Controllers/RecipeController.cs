using CulinaryRecipeAPI.Infrastructure.Dto.Response;
using CulinaryRecipeAPI.Infrastructure.Filters.RecipeFilters;
using CulinaryRecipeAPI.Infrastructure.Map.RecipeMapper;
using CulinaryRecipeAPI.Infrastructure.Models;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Services; 
using Microsoft.AspNetCore.Mvc;

namespace CulinaryRecipeAPI.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeServiceAsync _recipeServiceAsync;
        private readonly IRecipeMapper _recipeMapper; 
        public RecipeController(
            RecipeServiceAsync recipeServiceAsync, 
            IRecipeMapper recipeMapper
            )
        {
            _recipeServiceAsync = recipeServiceAsync;
            _recipeMapper = recipeMapper;
        }
        [ProducesResponseType(typeof(RecipeResponseDto), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeResponseDto>>> GetRecipes()
        {
            var recipes = await _recipeServiceAsync.GetAllRecipes();
            var mappedRecipes = _recipeMapper.ToIEnumerableRecipeResonseDto(recipes);
            return Ok(mappedRecipes);
        }
        [ProducesResponseType(typeof(RecipeResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RecipeResponseDto>> GetRecipeById(int id)
        {
            var recipe = await _recipeServiceAsync.GetRecipeById(id);
            var mappedRecipe = _recipeMapper.ToRecipeResponseDto(recipe);
            return Ok(mappedRecipe);
        }
        [ProducesResponseType(typeof(RecipeResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpPost]
        [ServiceFilter(typeof(RecipeCreateFilter))]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> CreateRecipe([FromForm] RecipeDto recipeDto)
        {
            var recipe = await _recipeServiceAsync.CreateRecipe(recipeDto);
            var mappedRecipe = _recipeMapper.ToRecipeResponseDto(recipe);
            return CreatedAtAction(
                nameof(GetRecipeById),
                new { id = mappedRecipe.Id },
                mappedRecipe);
        }
        [ProducesResponseType(typeof(RecipeResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(RecipeModifyFilter))]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<RecipeResponseDto>> UpdateRecipe(int id,[FromForm] RecipeDto recipeDto)
        {
            var recipe = await _recipeServiceAsync.UpdateRecipe(id, recipeDto);
            var mappedRecipe = _recipeMapper.ToRecipeResponseDto(recipe);
            return Ok(mappedRecipe);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(RecipeModifyFilter))]
        public async Task<ActionResult> DeleteRecipe(int id)
        {
            await _recipeServiceAsync.RemoveRecipeById(id);
            return NoContent();
        }
    }
}
