using ChoOnlineAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        [HttpGet("{buyerId:int}")]
        public IActionResult GetCart([FromRoute] int buyerId)
        {
            return StatusCode(501);
        }

        [HttpPost("{buyerId:int}/items")]
        public IActionResult AddItem([FromRoute] int buyerId, [FromBody] CartItemRequest request)
        {
            return StatusCode(501);
        }

        [HttpPut("{buyerId:int}/items/{productId:int}")]
        public IActionResult UpdateItem([FromRoute] int buyerId, [FromRoute] int productId, [FromBody] CartItemRequest request)
        {
            return StatusCode(501);
        }

        [HttpDelete("{buyerId:int}/items/{productId:int}")]
        public IActionResult RemoveItem([FromRoute] int buyerId, [FromRoute] int productId)
        {
            return StatusCode(501);
        }

        [HttpDelete("{buyerId:int}")]
        public IActionResult ClearCart([FromRoute] int buyerId)
        {
            return StatusCode(501);
        }
    }
}




