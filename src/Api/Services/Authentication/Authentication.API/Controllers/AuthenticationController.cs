using Authentication.API.Models;
using Authentication.API.Services;
using Authentication.API.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost("[controller]/register")]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            try
            {
                var user = await _userPrivateProfilesService.RegisterUserAsync(request);

                var token = JwtUtils.GenerateJWT(user, _configuration);

                PutTokenIntoCookies(token);

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

        [HttpPost("[controller]/login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _userPrivateProfilesService.ValidateCredentialsAndReturnProfileAsync(request);

                var token = JwtUtils.GenerateJWT(user, _configuration);

                PutTokenIntoCookies(token);

                return Ok();
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
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private void PutTokenIntoCookies(string token)
        {
            var accessMinutes = _configuration.GetValue("Jwt:AccessTokenMinutes", 15);

            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddMinutes(accessMinutes)
            });
        }

        [Authorize]
        [HttpPost("[controller]/logout")]
        public async Task<ActionResult> LogoutAsync()
        {
            Response.Cookies.Delete("jwt");

            return Ok();
        }

        [Authorize]
        [HttpGet("[controller]/me")]
        public ActionResult Me()
        {
            if (User?.Identity == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Not authenticated");
            }

            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var login = User.Identity?.Name;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            return Ok(new { Id = id, Login = login, Role = role });
        }
    }
}
