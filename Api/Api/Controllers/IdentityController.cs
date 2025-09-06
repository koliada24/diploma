using Api.DTOs;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IJwtService _jwtService;

        public IdentityController(IUsersService usersService, IJwtService jwtService)
        {
            _usersService = usersService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            var user = await _usersService.RegisterUser(registerUserDTO);

            var token = _jwtService.GenerateTokenForUser(user);
            SetTokenCookie(token);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginDTO)
        {
            var isValid = await _usersService.ValidateUserCredentials(loginDTO.Username, loginDTO.Password);

            if (!isValid)
            {
                return Unauthorized();
            }

            var user = await _usersService.GetUserByUsername(loginDTO.Username);

            var token = _jwtService.GenerateTokenForUser(user);
            SetTokenCookie(token);

            return Ok();
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("jwt_token", token, cookieOptions);
        }
    }
}
