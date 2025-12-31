using CulinaryRecipeAPI.Infrastructure.Models;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace CulinaryRecipeAPI.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController: ControllerBase
    {
        private readonly AuthorizationServiceAsync _authorizationServiceAsync;
        public AuthorizationController(AuthorizationServiceAsync authorizationServiceAsync) 
        { 
            _authorizationServiceAsync = authorizationServiceAsync;
        }
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(String), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<String>> GenerateAuthorizationToken([FromBody] AuthorizationUserDto authorizationUserDto)
        {
            var token = await _authorizationServiceAsync.GenerateAuthorizationToken(authorizationUserDto);
            return Ok(token);
        }
    }
}
