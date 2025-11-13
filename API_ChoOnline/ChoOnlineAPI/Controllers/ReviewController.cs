using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Review review)
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







