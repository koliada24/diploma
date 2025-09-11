using Api.DTOs.Identity;
using Api.Interfaces.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : AppBaseController
    {
        private readonly IUsersService _usersService;
        private readonly IJwtService _jwtService;

        public IdentityController(IUsersService usersService, IJwtService jwtService)
        {
            _usersService = usersService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            var user = await _usersService.RegisterUserAsync(registerUserDTO);

            var token = _jwtService.GenerateTokenForUser(user);
            Response.Cookies.Append("jwt_token", token);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserDTO loginDTO)
        {
            var isValid = await _usersService.ValidateUserCredentialsAsync(loginDTO.Username, loginDTO.Password);

            if (!isValid)
            {
                return Unauthorized();
            }

            var user = await _usersService.GetUserByUsernameAsync(loginDTO.Username);

            var token = _jwtService.GenerateTokenForUser(user);
            Response.Cookies.Append("jwt_token", token);

            return Ok();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt_token");
            return Ok();
        }

        [HttpGet("me")]
        public ActionResult<AuthState> GetAuthStateInfo()
        {
            var currentAuthState = new AuthState
            {
                IsAuthenticated = false,
                CurrentUserName = string.Empty,
                CurrentUserId = Guid.Empty
            };

            if (Username != string.Empty)
            {
                currentAuthState.IsAuthenticated = true;
                currentAuthState.CurrentUserName = Username;
                currentAuthState.CurrentUserId = UserId;
            }

            return Ok(currentAuthState);
        }
    }
}
