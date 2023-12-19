using ApiAB202.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAB202.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _service;


        public TagsController(ITagService service)
        {
            _service = service;

        }


        [HttpGet]

        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();

            return StatusCode(StatusCodes.Status200OK, await _service.GetAsync(id));

        }

        [HttpPost]

        public async Task<IActionResult> Create([FromForm] CreateTagDto tagDto)
        {

            await _service.Create(tagDto);

            return StatusCode(StatusCodes.Status201Created);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, string name)
        {

            if (id <= 0) return BadRequest();
            await _service.UpdateAsync(id, name);

            return NoContent();

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {

            if (id <= 0) return BadRequest();
            await _service.DeleteAsync(id);
            return NoContent();

        }
    }
}
