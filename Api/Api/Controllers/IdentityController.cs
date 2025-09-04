using Api.DTOs;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public IdentityController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            var userId = await _usersService.RegisterUser(registerUserDTO);
            return Ok(userId);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginDTO)
        {
            var isValid = await _usersService.ValidateUserCredentials(loginDTO.Username, loginDTO.Password);

            if (!isValid)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
