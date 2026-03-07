using Authentication.API.Models;
using Authentication.API.Services;
using Authentication.API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserPrivateProfilesService _userPrivateProfilesService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserPrivateProfilesService userPrivateProfilesService, IConfiguration configuration)
        {
            _userPrivateProfilesService = userPrivateProfilesService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            try
            {
                var user = await _userPrivateProfilesService.RegisterUserAsync(request);

                var jwt = JwtUtils.GenerateJWT(user, _configuration);

                var accessMinutes = _configuration.GetValue("Jwt:AccessTokenMinutes", 15);

                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(accessMinutes)
                });

                return Created();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpPost("login")]
        //public Task<ActionResult> LoginAsync()
        //{
        //    // validates credentials
        //    // puts JWT in the cookies
        //}

        //[HttpPost("logout")]
        //public Task<ActionResult> LogoutAsync()
        //{
        //    // clears jwt form cookies
        //}

        //[HttpGet("refresh")]
        //public Task<ActionResult> RefreshTokenAsync()
        //{
        //    // issue refresh token
        //    // puts JWT in the cookies
        //}
    }
}
