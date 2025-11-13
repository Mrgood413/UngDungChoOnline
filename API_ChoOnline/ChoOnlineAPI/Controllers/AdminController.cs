using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IModerationLogRepository _moderationLogRepository;
        private readonly IReportRepository _reportRepository;

        public AdminController(
            IUserRepository userRepository,
            IModerationLogRepository moderationLogRepository,
            IReportRepository reportRepository)
        {
            _userRepository = userRepository;
            _moderationLogRepository = moderationLogRepository;
            _reportRepository = reportRepository;
        }
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







