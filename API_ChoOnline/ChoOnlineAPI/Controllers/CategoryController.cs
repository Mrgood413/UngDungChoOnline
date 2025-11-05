using ChoOnlineAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(501);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return StatusCode(501);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
            return StatusCode(501);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            return StatusCode(501);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return StatusCode(501);
        }
    }
}




