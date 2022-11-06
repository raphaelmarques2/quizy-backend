using Microsoft.AspNetCore.Mvc;
using Quizy.User.API.Dtos;
using Quizy.User.Domain.Dtos;
using Quizy.User.Domain.UseCases;

namespace Quizy.User.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        
        private readonly ILogger<UserController> _logger;
        private readonly CreateUserUseCase _createUser;
        private readonly GetUserByIdUseCase _getUserById;
        private readonly GetUserByEmailUseCase _getUserByEmail;

        public UserController(ILogger<UserController> logger, 
            CreateUserUseCase createUser, GetUserByIdUseCase getUserById, GetUserByEmailUseCase getUserByEmail)
        {
            _logger = logger;
            _createUser = createUser;
            _getUserById = getUserById;
            _getUserByEmail = getUserByEmail;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(string id)
        {
            var user = await _getUserById.ExecuteAsync(id);
            return Ok(user);
        }

        [HttpPost("")]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto body)
        {
            var user = await _createUser.ExecuteAsync(body.Name, body.Email);
            return CreatedAtAction(nameof(GetUserById), new { Id = user.Id }, user);
        }
    }
}