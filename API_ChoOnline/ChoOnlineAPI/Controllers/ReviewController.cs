using ChoOnlineAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] ReviewCreateRequest request)
        {
            return StatusCode(501);
        }

        [HttpGet("product/{productId:int}")]
        public IActionResult GetByProduct([FromRoute] int productId)
        {
            return StatusCode(501);
        }

        [HttpDelete("{reviewId:int}")]
        public IActionResult Delete([FromRoute] int reviewId)
        {
            return StatusCode(501);
        }
    }
}




