using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartTalentTechnicalTest.ApplicationServices;
using SmartTalentTechnicalTest.Dtos;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace SmartTalentTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserServices _userService;

        public AuthController(UserServices userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(loginDto loginDto)
        {
            var user = await _userService.ValidateUserCredentials(loginDto.Email, loginDto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email.Value),
                new Claim(ClaimTypes.Role, user.Type.Value.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh= true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);
            return Ok();
        }
    }
}
