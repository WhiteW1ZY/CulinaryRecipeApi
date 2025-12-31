using CulinaryRecipeAPI.Infrastructure.Dto.Response;
using CulinaryRecipeAPI.Infrastructure.Filters.UserFilters;
using CulinaryRecipeAPI.Infrastructure.Map.UserMapper;
using CulinaryRecipeAPI.Infrastructure.Models;
using CulinaryRecipeAPI.UseCases.Dto;
using CulinaryRecipeAPI.UseCases.Services; 
using Microsoft.AspNetCore.Mvc;

namespace CulinaryRecipeAPI.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServiceAsync _userServiceAsync;
        private readonly IUserMapper _userMapper; 
        public UserController(
            UserServiceAsync userServiceAsync, 
            IUserMapper userMapper
            ) 
        { 
            _userServiceAsync = userServiceAsync;
            _userMapper = userMapper;
        } 
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
        {
            var users = await _userServiceAsync.GetAllUsers();
            var mappedUsers = _userMapper.ToIEnumberableUserResponseDto(users);
            return Ok(mappedUsers);
        }
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserResponseDto>> GetUserById(int id)
        {
            var user = await _userServiceAsync.GetUserById(id);
            var mappedUser = _userMapper.ToUserResponseDto(user);
            return Ok(mappedUser);
        }
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> CreateUser([FromBody] UserDto userDto)
        { 
            var user = await _userServiceAsync.CreateUser(userDto);
            var mappedUser = _userMapper.ToUserResponseDto(user);
            return CreatedAtAction(
                nameof(GetUserById),
                new {id = mappedUser.Id},
                mappedUser);
        }
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(UserModifyFilter))]
        public async Task<ActionResult<UserResponseDto>> UpdateUser(int id,[FromBody] UserDto userDto)
        { 
            var user = await _userServiceAsync.UpdateUser(id, userDto);
            var mappedUser = _userMapper.ToUserResponseDto(user);
            return Ok(mappedUser);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status403Forbidden)]
        [HttpDelete("{id:int}")]
        [ServiceFilter(typeof(UserModifyFilter))]
        public async Task<ActionResult> RemoveUser(int id)
        {
            await _userServiceAsync.RemoveUserById(id);
            return NoContent();
        }
    }
}
