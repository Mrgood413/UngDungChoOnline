using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        [HttpGet("user/{userId:int}")]
        public async Task<IActionResult> GetByUser([FromRoute] int userId)
        {
            return StatusCode(501);
        }

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct([FromRoute] int productId)
        {
            return StatusCode(501);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Favorite favorite)
        {
            return StatusCode(501);
        }

        [HttpDelete("{favoriteId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int favoriteId)
        {
            return StatusCode(501);
        }

        [HttpDelete("user/{userId:int}/product/{productId:int}")]
        public async Task<IActionResult> DeleteByUserAndProduct([FromRoute] int userId, [FromRoute] int productId)
        {
            return StatusCode(501);
        }

        [HttpGet("user/{userId:int}/product/{productId:int}/exists")]
        public async Task<IActionResult> CheckExists([FromRoute] int userId, [FromRoute] int productId)
        {
            return StatusCode(501);
        }
    }
}

