using ChoOnlineAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] OrderCreateRequest request)
        {
            return StatusCode(501);
        }

        [HttpGet("buyer/{buyerId:int}")]
        public IActionResult GetByBuyer([FromRoute] int buyerId)
        {
            return StatusCode(501);
        }

        [HttpGet("{orderId:int}")]
        public IActionResult GetDetail([FromRoute] int orderId)
        {
            return StatusCode(501);
        }

        [HttpPut("{orderId:int}/status")]
        public IActionResult UpdateStatus([FromRoute] int orderId, [FromBody] OrderStatusUpdateRequest request)
        {
            return StatusCode(501);
        }
    }
}




