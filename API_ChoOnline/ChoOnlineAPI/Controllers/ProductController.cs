using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
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
        public IActionResult Create([FromBody] Product product)
        {
            return StatusCode(501);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Product product)
        {
            return StatusCode(501);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return StatusCode(501);
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string? keyword, [FromQuery] int? categoryId, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string? location)
        {
            return StatusCode(501);
        }
    }
}



