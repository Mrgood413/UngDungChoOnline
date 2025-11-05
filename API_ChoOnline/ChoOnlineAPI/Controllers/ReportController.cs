using ChoOnlineAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] ReportCreateRequest request)
        {
            return StatusCode(501);
        }

        [HttpGet("pending")]
        public IActionResult GetPending()
        {
            return StatusCode(501);
        }

        [HttpPut("{reportId:int}/status")]
        public IActionResult UpdateStatus([FromRoute] int reportId, [FromBody] ReportStatusUpdateRequest request)
        {
            return StatusCode(501);
        }
    }
}




