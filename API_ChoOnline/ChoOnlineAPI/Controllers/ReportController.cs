using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Report report)
        {
            return StatusCode(501);
        }

        [HttpGet("pending")]
        public IActionResult GetPending()
        {
            return StatusCode(501);
        }

        [HttpPut("{reportId:int}/status")]
        public IActionResult UpdateStatus([FromRoute] int reportId, [FromBody] Report report)
        {
            return StatusCode(501);
        }
    }
}







