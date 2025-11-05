using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : ControllerBase
    {
        [HttpGet("nearby")]
        public IActionResult GetNearbyStores([FromQuery] double lat, [FromQuery] double lng, [FromQuery] double radiusKm = 5)
        {
            return StatusCode(501);
        }
    }
}




