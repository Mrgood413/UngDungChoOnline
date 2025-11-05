using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpGet("users")]
        public IActionResult GetUsers([FromQuery] string? role, [FromQuery] string? status)
        {
            return StatusCode(501);
        }

        [HttpPut("users/{userId:int}/status")]
        public IActionResult UpdateUserStatus([FromRoute] int userId, [FromBody] string status)
        {
            return StatusCode(501);
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            return StatusCode(501);
        }
    }
}




