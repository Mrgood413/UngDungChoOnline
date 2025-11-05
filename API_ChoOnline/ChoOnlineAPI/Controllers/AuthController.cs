using ChoOnlineAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            return StatusCode(501);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            return StatusCode(501);
        }

        [HttpGet("profile/{userId:int}")]
        public IActionResult GetProfile([FromRoute] int userId)
        {
            return StatusCode(501);
        }
    }
}



