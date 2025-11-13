using ChoOnlineAPI.Models;
using ChoOnlineAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
        public IActionResult Create([FromBody] Category category)
        {
            return StatusCode(501);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Category category)
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





