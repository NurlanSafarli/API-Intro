
using ApiAB202.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAB202.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRepository _repository;
 

        public CategoriesController(AppDbContext context, IRepository repository)
        {
            _repository = repository;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take=3)
        {
            
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
          Category existed = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (existed == null) return NotFound();
            return Ok(existed);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDto categorydto)
        {
            Category category = new Category
            {
                Name = categorydto.Name,
            };
            await _context.Categories.AddAsync(category);
            return StatusCode(StatusCodes.Status201Created, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            Category existed = await _repository.GetByIdAsync(id);
            if (existed == null) return NotFound();
            existed.Name = name;
            _repository.Update(existed);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            Category existed = await _repository.GetByIdAsync(id);
            if (existed == null) return NotFound();
           _repository.Delete(existed);
            await _repository.SaveChangesAsync();
            return NoContent();

        }

    }
}
