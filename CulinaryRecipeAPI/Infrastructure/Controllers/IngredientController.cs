using CulinaryRecipeAPI.Infrastructure.Dto.Response;
using CulinaryRecipeAPI.Infrastructure.Filters.AdminOnlyFilter;
using CulinaryRecipeAPI.Infrastructure.Map.IngredientMapper;
using CulinaryRecipeAPI.Infrastructure.Models;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Services; 
using Microsoft.AspNetCore.Mvc;

namespace CulinaryRecipeAPI.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientServiceAsync _ingredientServiceAsync;
        private readonly IIngredientMapper _ingredientMapper;
        public IngredientController(
            IngredientServiceAsync ingredientServiceAsync,
            IIngredientMapper ingredientMapper
            )
        {
            _ingredientServiceAsync = ingredientServiceAsync;
            _ingredientMapper = ingredientMapper;
        }
        [ProducesResponseType(typeof(IngredientResponseDto), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientResponseDto>>> GetAllIngredients()
        {
            var ingredients = await _ingredientServiceAsync.GetAllIngredients();
            var mappedIngredients = _ingredientMapper.ToIEnumerableIngredientResponseDto(ingredients);
            return Ok(mappedIngredients);
        }
        [ProducesResponseType(typeof(IngredientResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IngredientResponseDto>> GetIngredientById(int id)
        {
            var ingredient = await _ingredientServiceAsync.GetIngredientById(id);
            var mappedIngredient = _ingredientMapper.ToIngredientResponseDto(ingredient);
            return Ok(mappedIngredient);
        }
        [ProducesResponseType(typeof(IngredientResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpPost]
        [ServiceFilter(typeof(AdminOnlyFilter))]
        public async Task<ActionResult> CreateIngredient([FromBody] IngredientDto ingredientDto)
        {
            var ingredient = await _ingredientServiceAsync.CreateIngredient(ingredientDto);
            var mappedIngredient = _ingredientMapper.ToIngredientResponseDto(ingredient);
            return CreatedAtAction(
                nameof(GetIngredientById),
                new { id = mappedIngredient.Id },
                mappedIngredient);
        }
        [ProducesResponseType(typeof(IngredientResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(AdminOnlyFilter))]
        public async Task<ActionResult<IngredientResponseDto>> UpdateIngredient(int id, [FromBody] IngredientDto ingredientDto)
        {
            var ingredient = await _ingredientServiceAsync.UpdateIngredient(id, ingredientDto);
            var mappedIngredient = _ingredientMapper.ToIngredientResponseDto(ingredient);
            return Ok(mappedIngredient);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(AdminOnlyFilter))]
        public async Task<ActionResult> DeleteIngredient(int id)
        {
            await _ingredientServiceAsync.RemoveIngredient(id);
            return NoContent();
        }
    }
}
