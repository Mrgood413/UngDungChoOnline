using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Transaction transaction)
        {
            return StatusCode(501);
        }

        [HttpGet("buyer/{buyerId:int}")]
        public async Task<IActionResult> GetByBuyer([FromRoute] int buyerId)
        {
            return StatusCode(501);
        }

        [HttpGet("seller/{sellerId:int}")]
        public async Task<IActionResult> GetBySeller([FromRoute] int sellerId)
        {
            return StatusCode(501);
        }

        [HttpGet("{transactionId:int}")]
        public async Task<IActionResult> GetDetail([FromRoute] int transactionId)
        {
            return StatusCode(501);
        }

        [HttpPut("{transactionId:int}/status")]
        public async Task<IActionResult> UpdateStatus([FromRoute] int transactionId, [FromQuery] TransactionStatus status)
        {
            return StatusCode(501);
        }
    }
}







