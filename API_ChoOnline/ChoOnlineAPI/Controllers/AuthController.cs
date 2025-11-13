using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            return StatusCode(501);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
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



