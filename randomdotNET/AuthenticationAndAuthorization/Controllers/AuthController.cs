using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using randomdotNET.AuthenticationAndAuthorization.Models;
using randomdotNET.AuthenticationAndAuthorization.Services;

namespace randomdotNET.AuthenticationAndAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(TokenService tokenService) : ControllerBase
    {
        [HttpPost("get")]
        [Authorize]
        public IActionResult Get()
        {
            // Access headers from the request
            if (Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                // Log or process the Authorization header value
                return Ok($"Authorization Header: {authorizationHeader}");
            }

            return Unauthorized("Authorization header is missing.");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "password")
            {
                var token = tokenService.GenerateToken(model.Username, model.Role);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}